using Memento;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class Entrance : MonoBehaviour
{
    [SerializeField] private TMP_InputField _levelField;
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _loadButton;
    private string _path;
    private LevelBuilder _builder;
    private void Start()
    {
        _path = Path.Combine(Application.dataPath, "MyWayLALALA");
        _builder = new LevelBuilder(_path);
        _levelField.onValueChanged.AddListener(ChangeSavingPath);
        _saveButton.onClick.AddListener(_builder.SaveScene);
        _loadButton.onClick.AddListener(BuildLevel) ;
    }
    private void ChangeSavingPath(string path)
    {
        _builder.Path = path;
    }
    private void BuildLevel()
    {
        _builder.BuildLevel();
    }
}
