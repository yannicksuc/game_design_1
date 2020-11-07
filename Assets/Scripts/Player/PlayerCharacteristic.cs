using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class PlayerCharacteristic
    {
        public const uint Limit = 1;
        [Range(0,Limit)]
        public float ratio;
        public float cooldown;
    }
}
