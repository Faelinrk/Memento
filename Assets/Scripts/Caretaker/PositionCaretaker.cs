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
        private List<IMemento<Vector3Serializable>> _mementos = new List<IMemento<Vector3Serializable>>();

        private PositionOriginator _originator;

        public PositionCaretaker(PositionOriginator originator, string name)
        {
            this._originator = originator;
            _caretakerData.name = name;
        }


        public void Backup() // Creating mementos and feeding them to list
        { 
            this._mementos.Add(this._originator.Save());
            Debug.Log("Backup...");
        }

        public void Undo(bool remember = true)
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
                this.Undo(remember);
            }
                Debug.Log("Undo...");

            
        }

        public void ShowHistory()
        {
            foreach (var memento in this._mementos)
            {
                Debug.Log(memento.GetName());
            }
        }

        public PositionCaretakerData LoadData()
        {
            for(int i = 0; i < _mementos.Count; i++)
            {
                _caretakerData.positions.Add(_mementos[i].GetState());
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

