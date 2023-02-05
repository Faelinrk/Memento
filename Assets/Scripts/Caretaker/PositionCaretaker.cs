using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using JsonDataSaver;

namespace Memento
{
    public class PositionCaretaker : ICaretaker
    {
        PositionCaretakerData _caretakerData = new PositionCaretakerData();
        public List<IMemento<Vector3Serializable>> Mementos { get; set; } = new List<IMemento<Vector3Serializable>>();

        private PositionOriginator _originator;

        public PositionCaretaker(PositionOriginator originator, string name)
        {
            this._originator = originator;
            _caretakerData.name = name;
        }


        public void Backup() // Creating mementos and feeding them to list
        { 
            this.Mementos.Add(this._originator.Save());
            Debug.Log("Backup...");
        }

        public void Undo(bool remember = true)
        {
            if (this.Mementos.Count == 0)
            {
                return;
            }

            var memento = this.Mementos.Last();
            this.Mementos.Remove(memento); // Removing last memento from list

            try
            {
                this._originator.Restore(memento); // Restoring memento from originator
            }
            catch (Exception)
            {
                this.Undo(remember);
            }
                Debug.Log("Undo...");

            
        }

        public void ShowHistory()
        {
            foreach (var memento in this.Mementos)
            {
                Debug.Log(memento.GetName());
            }
        }

        public PositionCaretakerData LoadData()
        {
            for(int i = 0; i < Mementos.Count; i++)
            {
                _caretakerData.positions.Add(Mementos[i].GetState());
            }
            return _caretakerData;
        }
    }
    [Serializable]
    public class PositionCaretakerData : ICaretaker
    {
        public string name { get; set; }
        public List<Vector3Serializable> positions { get; set; } = new List<Vector3Serializable>();
    }
}

