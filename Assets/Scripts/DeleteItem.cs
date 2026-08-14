using UnityEngine;

public class DeleteItem : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
    }
}
