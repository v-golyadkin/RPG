using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInput : MonoBehaviour
{
    InteractInput interactInput;
    AttackHandler attackedHandler;

    private void Awake()
    {
        interactInput = GetComponent<InteractInput>();
        attackedHandler = GetComponent<AttackHandler>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(interactInput.hoveringOverObject != null)
            {
                attackedHandler.Attack(interactInput.hoveringOverObject);
            }
        }
    }
}
