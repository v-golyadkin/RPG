using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHandler : MonoBehaviour
{
    public InteractableObject interactedObject;

    CharacterMovement characterMovement;

    [SerializeField] float interactRange = 0.5f;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        if (interactedObject != null)
        {
            ProcessInteract();
        }
    }

    void ProcessInteract()
    {
        float distance = Vector3.Distance(transform.position, interactedObject.transform.position);

        if (distance < interactRange)
        {
            interactedObject.Interact();
            characterMovement.Stop();

            interactedObject = null;
        }
        else
        {
            characterMovement.SetDestination(interactedObject.transform.position);
        }
    }
}
