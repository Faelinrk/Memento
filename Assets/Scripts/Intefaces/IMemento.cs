using System;

namespace Memento
{
    public interface IMemento<T>
    {
        string GetName();

        T GetState();

        DateTime GetDate();
    }

}
