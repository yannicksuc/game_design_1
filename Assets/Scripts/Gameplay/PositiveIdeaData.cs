using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "PositiveIdea", menuName = "DataHolder", order = 0)]
    public class PositiveIdeaData : ScriptableObject
    {
        public Image image;
        public new string name;
    }
}