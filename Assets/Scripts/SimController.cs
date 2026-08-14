using UnityEngine;

public class SimController : MonoBehaviour
{
    [SerializeField] PaletteController paletteController;
    [SerializeField] Transform[] wayPoints;
    [SerializeField] float palGenerateTime = 4.0f;
    float timeToGeneratePal;
    [SerializeField] public Transform elagazasEleje;
    [SerializeField] public Transform elagazasVege;
    [SerializeField] public Transform[] elagazasA;
    [SerializeField] public Transform[] elagazasB;

    [SerializeField] public Transform Szemetes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GeneratePal();
    }

    // Update is called once per frame
    void Update()
    {
        timeToGeneratePal -= Time.deltaTime;
        if (timeToGeneratePal < 0)
        {
            GeneratePal();
        }

    }

    void GeneratePal()
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
