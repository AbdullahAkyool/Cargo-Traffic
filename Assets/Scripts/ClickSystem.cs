using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class ClickSystem : MonoBehaviour
{
    public GameObject currentCargo = null;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (LookGameObject(out RaycastHit hit))
            {
                SelectObject(hit.collider.gameObject);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (LookGameObject(out RaycastHit hit))
            {
                DeSelectObject(hit.collider.gameObject);
            }
        }    
    }

    private bool LookGameObject(out RaycastHit hit)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit);
    }

    private void SelectObject(GameObject targetObject)
    {
        if (targetObject.TryGetComponent(out Cargo cargo))
        {
            currentCargo = cargo.gameObject;
            cargo.MoveToFinalPoint();
        }
    }

    private void DeSelectObject(GameObject targetObject)
    {
        if (targetObject.TryGetComponent(out Cargo cargo))
        {
            currentCargo = null;
        }
    }
}
