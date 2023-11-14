using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class MouseInput : MonoBehaviour
{
    [HideInInspector]
    public Vector3 mouseInputPosition;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue))
        {
            mouseInputPosition = hit.point;
        }
    }
}
