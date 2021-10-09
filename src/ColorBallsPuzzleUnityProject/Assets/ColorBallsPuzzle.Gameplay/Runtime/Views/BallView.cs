using System;
using System.Globalization;
using Dreamteck.Splines;
using TMPro;
using UnityEngine;

namespace ColorBallsPuzzle.Gameplay.Views
{
    public class BallView : MonoBehaviour
    {
        public float CurrentPositionOnPath;
        public Renderer BallRenderer;
        public TextMeshPro Text;
        
        public void UpdateView(Vector3 position, int level, Color color)
        {
            transform.position = position;
            BallRenderer.material.color = color;
            Text.SetText(Math.Pow(2, level + 1).ToString(CultureInfo.InvariantCulture));
        }
        
        public void UpdateView(Vector3 position, int level, Color color, float currentPositionOnPath)
        {
            transform.position = position;
            BallRenderer.material.color = color;
            Text.SetText(Math.Pow(2, level + 1).ToString(CultureInfo.InvariantCulture));
            CurrentPositionOnPath = currentPositionOnPath;
        }
        
        public void UpdateView(Vector3 position, Vector3 direction, int level, Color color, float currentPositionOnPath)
        {
            transform.position = position;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            BallRenderer.material.color = color;
            Text.SetText(Math.Pow(2, level + 1).ToString(CultureInfo.InvariantCulture));
            CurrentPositionOnPath = currentPositionOnPath;
        }
    }
}