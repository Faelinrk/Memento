using Memento;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    [SerializeField] private Transform square, circle, hexagon;
    PositionOriginator squareOriginator;
    PositionOriginator circleOriginator;
    PositionOriginator hexagonOriginator;
    PositionCaretaker squareCaretaker;
    PositionCaretaker circleCaretaker;
    PositionCaretaker hexagonCaretaker;
    private void Start() // Creating originators and caretakers
    {
        squareOriginator = new PositionOriginator(square);
        circleOriginator = new PositionOriginator(circle);
        hexagonOriginator = new PositionOriginator(hexagon);
        squareCaretaker = new PositionCaretaker(squareOriginator);
        circleCaretaker = new PositionCaretaker(circleOriginator);
        hexagonCaretaker = new PositionCaretaker(hexagonOriginator);
    }
    private void Update() // Attaching input manager
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            square.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            squareOriginator.ChangePosition(square.position); // Changing state in Originator
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            circle.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            circleOriginator.ChangePosition(circle.position); // Changing state in Originator
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            hexagon.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hexagonOriginator.ChangePosition(hexagon.position); // Changing state in Originator
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            squareCaretaker.Backup(); // Doing backups with Caretaker
            circleCaretaker.Backup(); // Doing backups with Caretaker
            hexagonCaretaker.Backup(); // Doing backups with Caretaker
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            squareCaretaker.ShowHistory(); // Showing history of Caretaker
            circleCaretaker.ShowHistory();
            hexagonCaretaker.ShowHistory();
            squareCaretaker.Undo(); // Undoing actions
            circleCaretaker.Undo();
            hexagonCaretaker.Undo();
            
        }
    }
}
