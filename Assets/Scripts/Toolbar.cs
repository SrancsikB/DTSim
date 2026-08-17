using UnityEngine;

public class Toolbar : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform toolbarPanel;
    public ItemData[] availableItems;

    private void Start()
    {
        PopulateToolbar();
    }

    void PopulateToolbar()
    {
        foreach (var itemData in availableItems)
        {
            GameObject slot = Instantiate(slotPrefab, toolbarPanel);
            ItemSlot draggable = slot.GetComponent<ItemSlot>();
            
            if (draggable != null)
            {
                draggable.Setup(itemData);
            }
        }
    }
}