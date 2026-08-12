using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image icon;

    private ItemData item;
    private GameObject dragObject;

    public void SetItem(ItemData newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item == null)
            return;

        dragObject = new GameObject("DraggingItem");

        Image image = dragObject.AddComponent<Image>();
        image.sprite = item.icon;
        image.raycastTarget = false;

        dragObject.transform.SetParent(transform.root);
        dragObject.transform.SetAsLastSibling();

        UpdateDragPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragObject == null)
            return;

        UpdateDragPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragObject == null)
            return;

        Destroy(dragObject);

        PlacementManager.Instance.TryPlaceItem(item, eventData.position);
    }

    private void UpdateDragPosition(PointerEventData eventData)
    {
        dragObject.transform.position = eventData.position;
    }
}
