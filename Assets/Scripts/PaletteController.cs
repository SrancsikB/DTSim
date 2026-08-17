using UnityEngine;

public class PaletteController : MonoBehaviour
{

    public Transform[] wayPoints;
    int wayPointIndex = 0;
    [SerializeField] float movingSpeed=2.0f;
    [SerializeField] SimController simController;
    [SerializeField] public bool torott;

    public enum State
    {
        MovingOnPath,
        InBranch,
        ToTheTrashCan
    }
    public State currentState = State.MovingOnPath;
    private int branchIndex = 0;
    private Transform[] activeBranch;
    

    void Awake()
    {
        simController = Object.FindFirstObjectByType<SimController>();

        if (simController == null)
            Debug.LogError("Nincs SimController a jelenetben!");



    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        torott = Random.Range(1, 101) < 10 ? true : false;
        transform.position = wayPoints[wayPointIndex].position;
        wayPointIndex += 1;
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        switch (currentState)
        {
            case State.MovingOnPath:
                MovingOnPath(spriteRenderer);
                break;
            case State.InBranch:
                InBranch();
                break;
            case State.ToTheTrashCan:
                ToTheTrashCan();
                break;

        }

    }
    private void MovingOnPath(SpriteRenderer spriteRenderer)
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
                    activeBranch = (spriteRenderer.color == Color.green) ? simController.elagazasA : simController.elagazasB;
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
    private void InBranch()
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
    private void ToTheTrashCan()
    {
        if (torott) 
        {
            transform.position = Vector3.MoveTowards(transform.position, simController.Szemetes.position, movingSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, simController.Szemetes.position) < 0.05f)
            {
                transform.position = simController.Szemetes.position;
                Invoke("DestroyPalette", 1.0f);
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
    
    void DestroyPalette()
    {
        Destroy(gameObject);
    }

}
