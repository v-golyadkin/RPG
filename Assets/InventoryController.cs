using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector] public ItemGrid selectedItemGrid;

    Vector2Int positionOnGrid;
    InventoryItem selectedItem;
    RectTransform selectedItemRectTransform;

    [SerializeField] List<ItemData> itemDatas;
    [SerializeField] GameObject inventoryItemPrefab;
    [SerializeField] Transform targetCanvas;

    private void Update()
    {
        ProcessMouseInput();

        if (Input.GetKeyDown(KeyCode.A))
        {
            AddRandomItemToInventory();
        }
    }

    private void AddRandomItemToInventory()
    {
        GameObject newItemGO = Instantiate(inventoryItemPrefab);

        InventoryItem newInventoryItem = newItemGO.GetComponent<InventoryItem>();
        selectedItem = newInventoryItem;

        RectTransform newItemRectTransform = newItemGO.GetComponent<RectTransform>();
        newItemRectTransform.SetParent(targetCanvas);
        selectedItemRectTransform = newItemRectTransform;

        int selectedItemId = UnityEngine.Random.Range(0, itemDatas.Count);
        newInventoryItem.Set(itemDatas[selectedItemId]);
    }

    private void ProcessMouseInput()
    {
        if (selectedItem != null)
        {
            selectedItemRectTransform.position = Input.mousePosition;
        }

        if (selectedItemGrid == null) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            positionOnGrid = selectedItemGrid.GetTileGridPosition(Input.mousePosition);
            if (selectedItem == null)
            {
                selectedItem = selectedItemGrid.PickUpItem(positionOnGrid);
                selectedItemRectTransform = selectedItem.GetComponent<RectTransform>();
            }
            else
            {
                selectedItemGrid.PlaceItem(selectedItem, positionOnGrid.x, positionOnGrid.y);
                selectedItem = null;
                selectedItemRectTransform = null;
            }
        }
    }
}
