using UnityEngine;

public class SimController : MonoBehaviour
{
    [SerializeField] PaletteController paletteController;
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] float palGenerateTime = 4.0f;
    float timeToGeneratePal;
    [SerializeField] public Transform elagazasEleje;
    [SerializeField] public Transform elagazasVege;
    [SerializeField] public Transform[] elagazasA;
    [SerializeField] public Transform[] elagazasB;

    [SerializeField] public Transform Szemetes;

    public void AddWaypont(Transform wayPoint) 
    {
        if (!wayPoints.Contains(wayPoint)) 
        {
            wayPoints.Add
        }
    }
    
    private void Start()
    {
        GeneratePal();
    }

    private void Update()
    {
        timeToGeneratePal -= Time.deltaTime;

        if (timeToGeneratePal < 0)
        {
            GeneratePal();
        }

    }

    private void GeneratePal()
    {
        timeToGeneratePal = palGenerateTime;
        GameObject newPal= Instantiate(paletteController.gameObject);
        newPal.GetComponent<PaletteController>().wayPoints = wayPoints;

    }

    private void OnDrawGizmos()
    {
        if (wayPoints == null || wayPoints.Length < 2)
        {
            return;
        }

        Gizmos.color = Color.cyan;

        for (int i = 0; i < wayPoints.Length; i++)
        {
            if (wayPoints[i] != null)
            {
                Gizmos.DrawWireSphere(wayPoints[i].position, 0.5f);

                int nextIndex = (i + 1) % wayPoints.Length;

                if (wayPoints[nextIndex] != null)
                {
                    Gizmos.DrawLine(wayPoints[i].position, wayPoints[nextIndex].position);
                }
            }
        }
    }

}
