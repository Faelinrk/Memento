using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memento
{
    public interface ICaretaker
    {
        public void Backup() { }

        public void Undo(bool remember = true) { }

        public void ShowHistory(){}
    }
}

