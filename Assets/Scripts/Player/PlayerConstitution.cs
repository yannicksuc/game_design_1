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

        public void OnDisable()
        {
            stress.Ratio = 0;
            breath.Ratio = 0;
        }
    }
}
