using Memento;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEditor.ObjectChangeEventStream;

public class MementableObject : MonoBehaviour
{
    private PositionOriginator _originator;
    private PositionCaretaker _caretaker;
    private void Awake()
    {
        _originator = new PositionOriginator(gameObject.transform);
        _caretaker = new PositionCaretaker(_originator, "Hexagon");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Backup();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Undo();
        }
    }
    public void Undo(bool remember = true)
    {
        _caretaker.Undo(remember);
    }
    public void Backup()
    {
        _caretaker.Backup();
    }
    public PositionCaretakerData LoadData()
    {
        return _caretaker.LoadData();
    }
}
