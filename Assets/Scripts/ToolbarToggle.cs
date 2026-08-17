using UnityEngine;
using static UnityEditor.Progress;

public class ToolbarToggle : MonoBehaviour
{
    [SerializeField] private GameObject toolbar;
    private bool isActive = false;

    void Start()
    {
        toolbar.SetActive(false);
    }

    void Update()
    {
        if (toolbar is null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isActive = !isActive;
        }

        if (isActive) 
        {
            toolbar.SetActive(true);
        }
        else 
        {
            toolbar.SetActive(false);
        }
    }
}
