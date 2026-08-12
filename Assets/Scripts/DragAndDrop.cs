using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = transform.position.z;

        offset = transform.position - mouseWorldPosition;
    }

    private void OnMouseDrag()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = transform.position.z;

        transform.position = mouseWorldPosition + offset;
    }
}
