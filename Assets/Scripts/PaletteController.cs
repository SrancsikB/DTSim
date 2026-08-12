using UnityEngine;

public class PaletteController : MonoBehaviour
{

    public Transform[] wayPoints;
    int wayPointIndex = 0;
    [SerializeField] float movingSpeed=2.0f;
    [SerializeField] int oneOrTwo = 1;
    [SerializeField] SimController simController;

    private enum State
    {
        MovingOnPath,
        InBranch
    }
    private State currentState = State.MovingOnPath;
    private int branchIndex = 0;
    private Transform[] activeBranch;

    void Awake()
    {
        simController = FindObjectOfType<SimController>();

        if (simController == null)
            Debug.LogError("Nincs SimController a jelenetben!");



    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = wayPoints[wayPointIndex].position;
        wayPointIndex += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == State.MovingOnPath)
        {
            if (wayPointIndex < wayPoints.Length)
            {
                Vector3 target = wayPoints[wayPointIndex].position;
                transform.position = Vector3.MoveTowards(transform.position, target, movingSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, target) < 0.05f)
                {
                    transform.position = target;

                    if (wayPointIndex == SearchIndex(wayPoints, simController.elagazasEleje))
                    {
                        activeBranch = (oneOrTwo == 1) ? simController.elagazasA : simController.elagazasB;
                        branchIndex = 0;
                        currentState = State.InBranch;
                    }
                    else
                    {
                        wayPointIndex++;
                        if (wayPointIndex >= wayPoints.Length)
                        {
                            wayPointIndex = 0;
                        }
                    }

                }
            }

        }
        else if (currentState == State.InBranch)
        {
            if (branchIndex < activeBranch.Length)
            {
                Vector3 target = activeBranch[branchIndex].position;
                transform.position = Vector3.MoveTowards(transform.position, target, movingSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, target) < 0.05f)
                {
                    transform.position = target;
                    branchIndex++;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, simController.elagazasVege.position, movingSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, simController.elagazasVege.position) < 0.05f)
                {
                    transform.position = simController.elagazasVege.position;
                    currentState = State.MovingOnPath;
                    wayPointIndex = SearchIndex(wayPoints, simController.elagazasVege);
                }
            }
        }
    }
    private int SearchIndex(Transform[] elagazas, Transform target)
    {
        for (int i = 0; i < elagazas.Length; i++)
        {
            if (elagazas[i] == target)
            {
                return i;
            }
        }
        return -1;
    }
}
