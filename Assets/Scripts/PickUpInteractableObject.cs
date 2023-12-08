using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInteractableObject : MonoBehaviour
{
    [SerializeField] int coinCount;
    [SerializeField] ItemData itemData;

    private void Start()
    {
        GetComponent<InteractableObject>().interact += PickUp;    
    }

    public void PickUp(Inventory inventory)
    {
        inventory.AddCurrency(coinCount);

        if(itemData != null)
        {
            inventory.AddItem(itemData);
        }

        Debug.Log("Pick up");
        Destroy(gameObject);
    }
}
