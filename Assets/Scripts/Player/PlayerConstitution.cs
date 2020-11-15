using System;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "GameDesign1/PlayerConstitution")]
    public class PlayerConstitution : ScriptableObject
    {
        public PlayerStressCharacteristic stress;
        public PlayerBreathCharacteristic breath;

        public void OnDisable()
        {
            stress.Ratio = 0;
            breath.Ratio = 0;
        }
    }
}
