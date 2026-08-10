using UnityEngine;

public class SimController : MonoBehaviour
{
    [SerializeField] PaletteController paletteController;
    [SerializeField] Transform[] wayPoints;
    [SerializeField] float palGenerateTime = 4.0f;
    float timeToGeneratePal;

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

}
