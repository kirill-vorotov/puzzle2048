using UnityEngine;

namespace ColorBallsPuzzle.Gameplay.Views
{
    public class ProjectileLauncherView : MonoBehaviour
    {
        [SerializeField] private Transform _aimAssist;

        public void ShowAimAssist(Vector2 direction)
        {
            if (!_aimAssist.gameObject.activeSelf)
            {
                _aimAssist.gameObject.SetActive(true);
            }

            var dir = new Vector3(direction.x, 0f, direction.y);
            if (dir.sqrMagnitude > 0f)
            {
                _aimAssist.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.y), Vector3.up);
            }
        }

        public void HideAimAssist()
        {
            _aimAssist.gameObject.SetActive(false);
        }
    }
}