using UnityEngine;
using static UnityEditor.Progress;

public class ToolbarToggle : MonoBehaviour
{
    [SerializeField] private GameObject toolbar;

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

        if (Input.GetKeyDown(KeyCode.C) && !toolbar.activeSelf)
        {
            toolbar.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.V) && toolbar.activeSelf)
        {
            toolbar.SetActive(false);
        }
    }
}
