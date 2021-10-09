using System;
using UnityEngine;

namespace ColorBallsPuzzle.Gameplay.Views
{
    public class ExplosionView : MonoBehaviour
    {
        [SerializeField] private float _destroySelfAfterSeconds = 1f;
        [SerializeField] private float _startTime;
        [SerializeField] private ParticleSystem[] _particleSystems;
        private bool _destroying;
        
        public void Initialize(float destroySelfAfterSeconds)
        {
            _destroySelfAfterSeconds = destroySelfAfterSeconds;
            _startTime = Time.unscaledTime;
            if (_particleSystems == null)
            {
                return;
            }
            foreach (var particleSystem in _particleSystems)
            {
                if (particleSystem == null)
                {
                    continue;
                }

                particleSystem.Stop();
                particleSystem.Clear();
                particleSystem.Play();
            }
        }

        private void Start()
        {
            _startTime = Time.unscaledTime;
        }

        private void Update()
        {
            if (Time.unscaledTime > _startTime + _destroySelfAfterSeconds && !_destroying)
            {
                _destroying = true;
                Destroy(gameObject);
            }
        }
    }
}