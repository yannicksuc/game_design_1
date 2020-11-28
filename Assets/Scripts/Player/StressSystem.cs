using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Time;

namespace Player
{
    public class StressSystem : MonoBehaviour
    {
        [SerializeField] private PlayerConstitution constitution;

        void Update()
        {
            if (constitution.stress.Ratio >= PlayerCharacteristic.Limit)
                return;
            constitution.stress.Ratio += deltaTime / constitution.stress.cooldown;
        }
    }
}
