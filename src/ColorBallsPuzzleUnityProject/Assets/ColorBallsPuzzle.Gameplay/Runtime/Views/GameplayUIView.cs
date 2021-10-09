using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ColorBallsPuzzle.Gameplay.Views
{
    public class GameplayUIView : UIBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _heart1;
        [SerializeField] private Image _heart2;
        [SerializeField] private Image _heart3;

        public void UpdateHealth(Health playerHealth)
        {
            _heart1.enabled = playerHealth.Value > 0;
            _heart2.enabled = playerHealth.Value > 1;
            _heart3.enabled = playerHealth.Value > 2;
        }
        
        public void UpdateScore(int score)
        {
            
        }

        public void HideGoalText()
        {
            _text.enabled = false;
        }

        public void SetGoalText(BallLevel goal)
        {
            _text.enabled = true;
            var goalValue = Math.Pow(2, goal.Value + 1);
            _text.SetText($"Goal: {goalValue.ToString()}");
        }
    }
}