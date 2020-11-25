using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "PositiveIdea", menuName = "DataHolder", order = 0)]
    public class PositiveIdeaData : ScriptableObject
    {
        public Sprite sprite;
        public new string name;
        [HideInInspector] public int size;
    }
}