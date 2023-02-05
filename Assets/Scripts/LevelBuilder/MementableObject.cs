using Memento;
using UnityEngine;

public class MementableObject
{
    public PositionOriginator Originator;
    public PositionCaretaker Caretaker;
    public MementableObject(GameObject gameObject)
    {
        Originator = new PositionOriginator(gameObject.transform);
        Caretaker = new PositionCaretaker(Originator, "Hexagon");
    }
    public void InputManager()
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
        Caretaker.Undo(remember);
    }
    public void Backup()
    {
        Caretaker.Backup();
    }
    public PositionCaretakerData LoadData()
    {
        return Caretaker.LoadData();
    }
}
