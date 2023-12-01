using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector] public ItemGrid selectedItemGrid;

    Vector2Int positionOnGrid;
    InventoryItem selectedItem;

    private void Update()
    {
        if (selectedItemGrid == null) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            positionOnGrid = selectedItemGrid.GetTileGridPosition(Input.mousePosition);
            if(selectedItem == null)
            {
                selectedItem = selectedItemGrid.PickUpItem(positionOnGrid);
            }
            else
            {
                selectedItemGrid.PlaceItem(selectedItem, positionOnGrid.x, positionOnGrid.y);
                selectedItem = null;
            }
        }
    }

}
