using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace ColorBallsPuzzle.AssetManagement
{
    public class SceneAddressLoader : IDisposable
    {
        public enum Status
        {
            None = 0,
            Loading = 1,
            Ready = 2,
        }
        
        private AsyncOperationHandle<SceneInstance> _handle;
        private bool _markedToUnload;
        private bool _disposing;
        
        public readonly string Address;
        public Status CurrentStatus { get; private set; }

        public bool IsReady => 
            _handle.IsValid() && 
            _handle.IsDone && 
            _handle.Status == AsyncOperationStatus.Succeeded && 
            CurrentStatus == Status.Ready;
        
        public SceneAddressLoader(string address)
        {
            Address = address;
        }

        public async UniTask LoadAsync(LoadSceneMode loadSceneMode)
        {
            try
            {
                if (_disposing)
                {
                    Debug.LogWarning($"{ClassName()}.{nameof(LoadAsync)}: Disposing!");
                    return;
                }
            
                switch (CurrentStatus)
                {
                    case Status.Loading:
                    {
                        Debug.LogWarning($"{ClassName()}.{nameof(LoadAsync)}: Already loading.");
                        return;
                    }
                    case Status.Ready:
                    {
                        return;
                    }
                    case Status.None:
                    {
                        _handle = Addressables.LoadSceneAsync(Address, loadSceneMode);
                        CurrentStatus = Status.Loading;
                        await _handle.ToUniTask();
                        if (_handle.OperationException != null)
                        {
                            CurrentStatus = Status.None;
                            throw _handle.OperationException;
                        }
                    
                        switch (_handle.Status)
                        {
                            case AsyncOperationStatus.Succeeded:
                            {
                                CurrentStatus = Status.Ready;
                                if (_markedToUnload || _disposing)
                                {
                                    _ = UnloadAsync();
                                }
                                break;
                            }
                            case AsyncOperationStatus.None:
                            case AsyncOperationStatus.Failed:
                            {
                                CurrentStatus = Status.None;
                                throw new Exception($"{ClassName()}.{nameof(LoadAsync)}: Status: {_handle.Status}");
                            }
                            default:
                            {
                                CurrentStatus = Status.None;
                                throw new ArgumentOutOfRangeException($"{ClassName()}.{nameof(LoadAsync)}");
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        public async UniTask UnloadAsync(bool unloadWhenSceneIsReady = false)
        {
            try
            {
                switch (CurrentStatus)
                {
                    case Status.Loading:
                    {
                        _markedToUnload = unloadWhenSceneIsReady;
                        break;
                    }
                    case Status.Ready:
                    {
                        _markedToUnload = false;
                        CurrentStatus = Status.None;
                        await Addressables.UnloadSceneAsync(_handle).ToUniTask();
                        break;
                    }
                    case Status.None:
                    {
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                if (_disposing)
                {
                    return;
                }

                _disposing = true;
                UnloadAsync(true).Forget();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        private static string ClassName()
        {
            return $"{nameof(SceneAddressLoader)}";
        }
    }
}