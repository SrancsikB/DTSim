using UnityEngine;

public class Toolbar : MonoBehaviour
{
    [SerializeField] private ItemSlot[] slots;
    [SerializeField] private ItemData[] items;

    private void Start()
    {
        for (int i = 0; i < slots.Length && i < items.Length; i++)
        {
            slots[i].SetItem(items[i]);
        }
    }
}