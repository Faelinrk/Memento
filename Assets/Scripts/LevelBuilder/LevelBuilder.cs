using Cysharp.Threading.Tasks;
using Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelBuilder 
{
    private MementoSerialize<PositionCaretakerData> _serializer;
    private MementableObjectSpawner _spawner = new MementableObjectSpawner();
    private List<string> _objectNames;
    public List<MementableObject> _objects = new List<MementableObject>();
    private List<PositionCaretakerData> _positionCaretakerData = new List<PositionCaretakerData>();
    private string _path;
    public string Path { get => _path; set => _path = value; }

    public LevelBuilder(string path)
    {
        Path = path;
        _objectNames = new List<string>();
    }

    public async UniTask BuildLevelAsync()
    {
        LoadSerializer();
        var data = _serializer.DeserializeMemento();
        for (int i = 0; i < data.Count; i++)
        {
            _objectNames.Add(data[i].name);
        }
        for (int i = 0; i< _objectNames.Count; i++)
        {
            MementableObject obj = await _spawner.InstantiateMementoObjectAsync(_objectNames[i]);
            await UniTask.DelayFrame(100);
            for(int j = 0; j < data[i].positions.Count; j++)
            {
                obj.Caretaker.Mementos.Add(new PositionMemento(data[i].positions[j]));
            }
            obj.Undo(false);
        }
    }
    public void BuildLevel()
    {
        BuildLevelAsync();
     }

    public void SaveScene()
    {
        var objs = GameObject.FindObjectsOfType<ObjectView>();
        _objects = new List<MementableObject>();
        for (int i = 0; i < objs.Length; i++)
        {
            _objects.Add(objs[i].MementableObj);
        }
        LoadSerializer();
        _serializer.SerializeMemento();

    }

    private void LoadSerializer()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            _positionCaretakerData.Add(_objects[i].LoadData());
        }
        _serializer = new MementoSerialize<PositionCaretakerData>(Path, "data.json", _positionCaretakerData);
    }
}
