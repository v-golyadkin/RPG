using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{
    InventoryItem[,] inventoryItemGrid;

    const float TileSizeWidth = 32f;
    const float TileSizeHeight = 32f;

    [SerializeField] int gridSizeWidth;
    [SerializeField] int gridSizeHeight;

    RectTransform rectTransform;

    Vector2 mousePositionOnTheGrid;
    Vector2Int tileGridPosition = new Vector2Int();

    [SerializeField] GameObject inventoryItemPrefab;

    private void Start()
    {
        Init(gridSizeWidth, gridSizeHeight);
        GameObject itemTest = Instantiate(inventoryItemPrefab);
        InventoryItem inventoryItemTest = itemTest.GetComponent<InventoryItem>();
        PlaceItem(inventoryItemTest, 2, 2);
    }

    private void Init(int width, int height)
    {
        inventoryItemGrid = new InventoryItem[width, height];
        Vector2 size = new Vector2();
        size.x = TileSizeWidth * width;
        size.y = TileSizeHeight * height;
        rectTransform.sizeDelta = size;
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void PlaceItem(InventoryItem itemToPlace, int x, int y)
    {
        RectTransform itemRectTransform = itemToPlace.GetComponent<RectTransform>();
        itemRectTransform.SetParent(transform);

        inventoryItemGrid[x, y] = itemToPlace;

        Vector2 positionOnGrid = new Vector2();
        positionOnGrid.x = TileSizeWidth * x + TileSizeWidth / 2;
        positionOnGrid.y = -(TileSizeHeight * y + TileSizeHeight / 2);
        itemRectTransform.localPosition = positionOnGrid;
    }

    public Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {
        mousePositionOnTheGrid.x = mousePosition.x - rectTransform.position.x;
        mousePositionOnTheGrid.y = rectTransform.position.y - mousePosition.y;

        tileGridPosition.x = (int)(mousePositionOnTheGrid.x / TileSizeWidth);
        tileGridPosition.y = (int)(mousePositionOnTheGrid.y / TileSizeHeight);

        return tileGridPosition;
    }

    internal InventoryItem PickUpItem(Vector2Int tilePositionOnGrid)
    {
        InventoryItem pickedItem = inventoryItemGrid[tilePositionOnGrid.x, tilePositionOnGrid.y];
        inventoryItemGrid[tilePositionOnGrid.x, tilePositionOnGrid.y] = null;
        return pickedItem;
    }
}
