using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHighlight : MonoBehaviour
{
    [SerializeField] RectTransform highliter;

    public void SetSize(InventoryItem inventoryItem)
    {
        Vector2 size = new Vector2();
        size.x = inventoryItem.itemData.sizeWidth * ItemGrid.TileSizeWidth;
        size.y = inventoryItem.itemData.sizeHeight * ItemGrid.TileSizeHeight;
        highliter.sizeDelta = size;
    }

    public void SetPosition(ItemGrid targetGrid, InventoryItem targetItem)
    {
        highliter.SetParent(targetGrid.transform);

        Vector2 position = targetGrid.CalculatePositionOfObjectOnGrid(targetItem, targetItem.positionOnGridX, targetItem.positionOnGridY);

        highliter.localPosition = position;
    }
    
    public void Show(bool set)
    {
        highliter.gameObject.SetActive(set);    
    }

}
