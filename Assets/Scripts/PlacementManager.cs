using NUnit.Framework.Interfaces;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public static PlacementManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PlaceItem(ItemData itemData, Vector3 screenPosition)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPosition);
        worldPos.z = -1f;

        Instantiate(itemData.prefab, worldPos, Quaternion.identity);
    }
}