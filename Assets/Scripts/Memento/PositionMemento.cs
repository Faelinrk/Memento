using JsonDataSaver;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Memento
{
    // Position memento got info about state
    class PositionMemento : IMemento<Vector3Serializable>
    {
        private Vector3Serializable _state;

        private DateTime _date;

        public PositionMemento(Vector3Serializable state)
        {
            this._state = state;
            this._date = DateTime.Now;
        }

        // Restoring state
        public Vector3Serializable GetState()
        {
            return this._state;
        }

        // Caretaker using this methods to show meta data
        public string GetName()
        {
            return $"{this._date} / ({this._state})...";
        }

        public DateTime GetDate()
        {
            return this._date;
        }
    }

}
