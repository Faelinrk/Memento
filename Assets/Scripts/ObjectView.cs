using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectView : MonoBehaviour
{
    private MementableObject _mementableObj;
    public MementableObject MementableObj 
    { 
        get 
        { 
            if (_mementableObj == null)
                _mementableObj = new MementableObject(gameObject);
            return _mementableObj;
        }
    }
}
