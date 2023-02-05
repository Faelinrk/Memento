using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public sealed class MementableObjectSpawner
{

    public async UniTask<MementableObject> InstantiateMementoObjectAsync(string key)
    {
        AsyncOperationHandle<GameObject> loadOp = Addressables.LoadAssetAsync<GameObject>(key);
        await loadOp;
        if (loadOp.Status == AsyncOperationStatus.Succeeded)
        {
            var op = Addressables.InstantiateAsync(key);
        }
        var objectView = loadOp.Result.GetComponent<ObjectView>();
        return objectView.MementableObj;
    }
}
