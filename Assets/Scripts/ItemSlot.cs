using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image icon;

    private ItemData item;
    private GameObject dragObject;
    private RectTransform dragRectTransform;
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void SetItem(ItemData newItem)
    {
        item = newItem;
        if (item != null && item.icon != null)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
        }
        else
        {
            icon.enabled = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item == null) return;

        dragObject = new GameObject("DraggingItem");
        dragRectTransform = dragObject.AddComponent<RectTransform>();

        dragObject.transform.SetParent(canvas.transform, false);
        dragObject.transform.SetAsLastSibling();

        Image image = dragObject.AddComponent<Image>();
        image.sprite = item.icon;
        image.raycastTarget = false;

        dragRectTransform.sizeDelta = new Vector2(50f, 50f);

        UpdateDragPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragObject == null) return;

        UpdateDragPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragObject == null) return;

        Destroy(dragObject);

        PlacementManager.Instance.TryPlaceItem(item, eventData.position);
    }

    private void UpdateDragPosition(PointerEventData eventData)
    {
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            dragRectTransform.position = eventData.position;
        }
        else
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                canvas.worldCamera,
                out Vector2 localPoint
            );
            dragRectTransform.localPosition = localPoint;
        }
    }
}