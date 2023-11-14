using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] string postMessage;
    public string objectName;

    private void Awake()
    {
        objectName = transform.name;
    }

    public void Interact()
    {
        Debug.Log(postMessage);
    }
}
