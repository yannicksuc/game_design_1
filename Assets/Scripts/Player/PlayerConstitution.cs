using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "GameDesign1/PlayerConstitution")]
    public class PlayerConstitution : ScriptableObject
    {
        public PlayerCharacteristic stress;
        public PlayerCharacteristic breath;
    }
}
