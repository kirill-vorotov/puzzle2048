using ColorBallsPuzzle.Gameplay.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ColorBallsPuzzle.Gameplay.Views
{
    public class PlayerInputView : MonoBehaviour
    {
        [SerializeField] private Camera _gameplayCamera;
        [SerializeField] private OnScreenStick _onScreenStick;
        [SerializeField] private GameplaySceneController _gameplayController;
        [SerializeField] private Vector2 _touchPosition;
        private ColorBallsPuzzleInput _input;
        private bool _touch;

        private void Awake()
        {
            _input = new ColorBallsPuzzleInput();
            _input.Player.TouchPress.started += OnTouchPressStarted;
            _input.Player.TouchPress.performed += OnTouchPressPerformed;
            _input.Player.TouchRelease.performed += OnTouchReleasePerformed;
            _onScreenStick.PointerUp += OnScreenStickPointerUp;
        }

        private void OnTouchReleasePerformed(InputAction.CallbackContext obj)
        {
            _touchPosition = _input.Player.TouchPosition.ReadValue<Vector2>();
            var spawnerScreenPosition = _gameplayCamera.WorldToScreenPoint(_gameplayController.ProjectileSpawnerWorldPosition);
            var direction = _touchPosition - new Vector2(spawnerScreenPosition.x, spawnerScreenPosition.y);
            _gameplayController.LauchProjectile(direction);
            _touch = false;
        }

        private void OnTouchPressStarted(InputAction.CallbackContext context)
        {
            _touch = true;
        }
        
        private void OnTouchPressPerformed(InputAction.CallbackContext context)
        {
            
        }

        private void OnScreenStickPointerUp()
        {
            // if (_aimDirection.sqrMagnitude > 0.1f)
            // {
            //     _gameplayController.LauchProjectile(_aimDirection);
            // }
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void Update()
        {
            if (_touch)
            {
                _touchPosition = _input.Player.TouchPosition.ReadValue<Vector2>();
                var spawnerScreenPosition = _gameplayCamera.WorldToScreenPoint(_gameplayController.ProjectileSpawnerWorldPosition);
                var direction = _touchPosition - new Vector2(spawnerScreenPosition.x, spawnerScreenPosition.y);
                _gameplayController.UpdateLaunchDirection(direction);
            }
        }
    }
}