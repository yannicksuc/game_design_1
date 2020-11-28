using System;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "GameDesign1/PlayerConstitution")]
    public class PlayerConstitution : ScriptableObject
    {
        public PlayerStressCharacteristic stress;
        public PlayerBreathCharacteristic breath;
        [ShowOnly] public Vector2 velocity = Vector2.zero;

        public void OnEnable()
        {
            Reset();
        }
        
        public void OnDestroy()
        {
            Reset();
        }

        public void OnDisable()
        {
            Reset();
        }

        private void Reset()
        {
            stress.Ratio = 0;
            breath.Ratio = 0;
        }
    }
}
