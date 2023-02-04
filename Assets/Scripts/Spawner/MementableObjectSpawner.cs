using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public sealed class MementableObjectSpawner
{
    private AsyncOperationHandle<MementableObject> _currentUnitHandle;
    private MementableObject _unitInstance;

    public async UniTask<MementableObject> InstantiateMementoObjectAsync(string key)
    {
        AsyncOperationHandle<GameObject> loadOp = Addressables.LoadAssetAsync<GameObject>(key);
        await loadOp;
        if (loadOp.Status == AsyncOperationStatus.Succeeded)
        {
            var op = Addressables.InstantiateAsync(key);
        }
        return loadOp.Result.GetComponent<MementableObject>();
    }
}
