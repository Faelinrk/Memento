using System;
using UnityEngine;

namespace Memento
{
    public class PositionOriginator
    {
        // State is data stored in originator
        Transform _obj;
        private Vector2 _state;

        public PositionOriginator(Transform obj)
        {
            this._obj = obj;
            this._state = obj.position; // Changing state to object's position
        }

        public void ChangePosition(Vector2 position)
        {
            this._state = position;
        }

        // Saving position info in Memento
        public IMemento<Vector2> Save()
        {
            return new PositionMemento(this._state);
        }

        // Restoring data of originator's state
        public void Restore(IMemento<Vector2> memento)
        {
            if (!(memento is PositionMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }
            this._state = memento.GetState();
            _obj.position = this._state;
        }
    }

}

