using Memento;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class Entrance : MonoBehaviour
{
    const string DefauldSceneName = "Default";
    [SerializeField] private TMP_InputField _levelField;
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _loadButton;
    private string _path;
    private LevelBuilder _builder;
    MouseControl _mouseInput = new MouseControl();
    private void Start()
    {
        _path = Path.Combine(Application.dataPath, "Default");
        _builder = new LevelBuilder(_path);
        _levelField.onValueChanged.AddListener(ChangeSavingPath);
        _saveButton.onClick.AddListener(_builder.SaveScene);
        _loadButton.onClick.AddListener(_builder.BuildLevel) ;
    }
    private void ChangeSavingPath(string path)
    {
        _builder.Path = path;
    }
    private void Update()
    {
        foreach(var obj in FindObjectsOfType<ObjectView>())
        {
            obj.MementableObj.InputManager();
        }
        _mouseInput.InputManager();
    }
}
