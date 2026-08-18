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
        if (toolbar == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isActive = !isActive;
        }

        toolbar.SetActive(isActive);
    }
}
