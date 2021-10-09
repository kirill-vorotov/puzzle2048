using System;
using ColorBallsPuzzle.AssetManagement;
using ColorBallsPuzzle.Gameplay;
using ColorBallsPuzzle.UI;
using DG.Tweening;
using Facebook.Unity;
using MessagePack;
using MessagePack.Resolvers;
using MessagePack.Unity;
using MessagePack.Unity.Extension;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace ColorBallsPuzzle
{
    public static class AppStart
    {
        private const string uiSceneAddress = "Assets/Scenes/UI.unity";
        
        private static bool _messagePackInitialized;
        private static GameContext _gameContext;
        private static SceneAddressLoader _uiSceneLoader;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void OnSubsystemRegistration()
        {
            Debug.Log($"{nameof(AppStart)}.{nameof(OnSubsystemRegistration)}");
            // ReSharper disable once InvertIf
            if (!_messagePackInitialized)
            {
                StaticCompositeResolver.Instance.Register(
                    UnityResolver.Instance,
                    UnityBlitWithPrimitiveArrayResolver.Instance,
                    StandardResolver.Instance,
                    GeneratedResolver.Instance);
                var options = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);
                MessagePackSerializer.DefaultOptions = options;
                _messagePackInitialized = true;
            }
            DOTween.Init();
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void OnAfterAssembliesLoaded()
        {
            Debug.Log($"{nameof(AppStart)}.{nameof(OnAfterAssembliesLoaded)}");
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void OnBeforeSplashScreen()
        {
            Debug.Log($"{nameof(AppStart)}.{nameof(OnBeforeSplashScreen)}");
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnBeforeSceneLoad()
        {
            Debug.Log($"{nameof(AppStart)}.{nameof(OnBeforeSceneLoad)}");
            if (!FB.IsInitialized)
            {
                FB.Init(FBInitCallback, FBOnHideUnity);
            }
            else
            {
                FB.ActivateApp();
            }
            var amplitude = Amplitude.Instance;
            amplitude.logging = true;
            amplitude.init("c19a6ae4d6563354417fe175dfba4c95");
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static async void OnAfterSceneLoad()
        {
            Debug.Log($"{nameof(AppStart)}.{nameof(OnAfterSceneLoad)}");
            
            PlayerModel playerModel = null;
            try
            {
                playerModel = PlayerModelPlayerPrefsStorage.Read();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            
            playerModel ??= PlayerLogic.CreatePlayerModel(PlayerModelVersion.Parse(GameConstants.PlayerModelVersion));
            Assert.IsNotNull(playerModel);
            _gameContext = new GameContext()
            {
                Player = playerModel,
                Descriptions = DescriptionsFactory.CreateDescriptions(),
            };
            PlayerModelPlayerPrefsStorage.Write(_gameContext.Player);
            
            _uiSceneLoader?.Dispose();
            _uiSceneLoader = new SceneAddressLoader(uiSceneAddress);
            await _uiSceneLoader.LoadAsync(LoadSceneMode.Additive);
            var uiSceneController = Object.FindObjectOfType<UISceneController>();
            if (uiSceneController != null)
            {
                uiSceneController.Initialize(_gameContext);
            }
        }

        // ReSharper disable once InconsistentNaming
        private static void FBInitCallback()
        {
            if (FB.IsInitialized)
            {
                FB.ActivateApp();
            }
        }

        private static void FBOnHideUnity(bool isGameShown)
        {
            
        }
    }
}