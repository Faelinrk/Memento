
namespace JsonDataSaver
{
    public interface IData<T>
    {
        void Save(T data, string path = null, string filename = null);
        T Load(string path = null, string filename = null);
    }
}

