using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Memento
{
    public class PositionCaretaker // 
    {
        private List<IMemento<Vector2>> _mementos = new List<IMemento<Vector2>>();

        private PositionOriginator _originator;

        public PositionCaretaker(PositionOriginator originator)
        {
            this._originator = originator;
        }

        public void Backup() // Creating mementos and feeding them to list
        { 
            this._mementos.Add(this._originator.Save());
            Debug.Log("backup...");
        }

        public void Undo()
        {
            if (this._mementos.Count == 0)
            {
                return;
            }

            var memento = this._mementos.Last();
            this._mementos.Remove(memento); // Removing last memento from list

            try
            {
                this._originator.Restore(memento); // Restoring memento from originator
            }
            catch (Exception)
            {
                this.Undo();
            }
            Debug.Log("undo...");
        }

        public void ShowHistory()
        {
            foreach (var memento in this._mementos)
            {
                Debug.Log(memento.GetName());
            }
        }
    }
}

