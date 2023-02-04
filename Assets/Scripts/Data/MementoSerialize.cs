using JsonDataSaver;
using System.Collections.Generic;
using UnityEngine;

namespace Memento
{
    public class MementoSerialize<ICaretakerData>
    {
        private List<ICaretakerData> _dataList = new List<ICaretakerData>();
        private JsonData<List<ICaretakerData>> _jsonSerializer = new JsonData<List<ICaretakerData>>();
        private string _path;
        private string _fileName;
        
        public MementoSerialize(string path, string fileName, List<ICaretakerData> dataList)
        {
            this._dataList = dataList;
            this._path = path;
            this._fileName = fileName;
        }

        public void SerializeMemento()
        {
            _jsonSerializer.Save(_dataList, _path, _fileName);
        }
        public List<ICaretakerData> DeserializeMemento()
        {
            _dataList = _jsonSerializer.Load(_path, _fileName);
            return _dataList;
        }
    }
}
