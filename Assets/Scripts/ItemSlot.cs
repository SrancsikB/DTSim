using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemData itemData;
    
    private GameObject draggingIcon;
    private Canvas rootCanvas;

    private void Awake()
    {
        rootCanvas = GetComponentInParent<Canvas>();
    }

    public void Setup(ItemData data)
    {
        itemData = data;
        GetComponent<Image>().sprite = data.icon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingIcon = new GameObject("DraggingIcon");
        draggingIcon.transform.SetParent(rootCanvas.transform, false);
        draggingIcon.transform.SetAsLastSibling();

        Image img = draggingIcon.AddComponent<Image>();
        img.sprite = itemData.icon;
        img.raycastTarget = false; 
        RectTransform rt = draggingIcon.GetComponent<RectTransform>();
        rt.sizeDelta = GetComponent<RectTransform>().sizeDelta;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggingIcon != null)
        {
            draggingIcon.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggingIcon != null)
        {
            Destroy(draggingIcon);
        }

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            PlacementManager.Instance.PlaceItem(itemData, Input.mousePosition);
        }
    }
}