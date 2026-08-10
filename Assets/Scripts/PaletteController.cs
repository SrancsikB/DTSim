using UnityEngine;

public class PaletteController : MonoBehaviour
{

    public Transform[] wayPoints;
    int wayPointIndex = 0;
    [SerializeField] float movingSpeed=2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = wayPoints[wayPointIndex].position;
        wayPointIndex += 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[wayPointIndex].position, movingSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, wayPoints[wayPointIndex].position)<0.05)
        {
            transform.position = wayPoints[wayPointIndex].position;
            wayPointIndex += 1;
            if (wayPointIndex >= wayPoints.Length)
            {
                wayPointIndex = 0;
            }
        }
    }
}
