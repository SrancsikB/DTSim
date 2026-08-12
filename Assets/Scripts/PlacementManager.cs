using NUnit.Framework.Interfaces;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public static PlacementManager Instance;

    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        Instance = this;
    }

    public void TryPlaceItem(ItemData item, Vector2 screenPosition)
    {
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(
            new Vector3(
                screenPosition.x,
                screenPosition.y,
                -mainCamera.transform.position.z
            )
        );

        worldPosition.z = 0f;

        Instantiate(item.prefab, worldPosition, Quaternion.identity);
    }
}