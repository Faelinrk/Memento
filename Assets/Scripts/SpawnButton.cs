using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : Button
{
    private MementableObjectSpawner _spawner = new MementableObjectSpawner();
    protected override void Start()
    {
        onClick.AddListener(delegate { SpawnObject(GetComponentInChildren<TMP_Text>().text); });
    }
    private void SpawnObject(string name)
    {
        _spawner.InstantiateMementoObjectAsync(name);
    }
}
