using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseControl
{
    private Transform _selectedObject;
    private MementableObject _mementableObject;
    public void InputManager()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            _selectedObject = hit.transform;
            if(_selectedObject is not null && _selectedObject.TryGetComponent(out ObjectView view))
            {
                _mementableObject = view.MementableObj;
                _selectedObject.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_selectedObject)
            {
                _mementableObject.Originator.ChangePosition(_selectedObject.position);
                _selectedObject = null;
            }
        }
    }
}
