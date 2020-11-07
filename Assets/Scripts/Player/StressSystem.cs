using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Time;

namespace Player
{
    public class StressSystem : MonoBehaviour
    {
        [SerializeField] private PlayerConstitution constitution;
        [Tooltip("Time in second to reach the stress limit")]
        public UnityEvent onPlayerStressedOut;
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            constitution.stress.ratio += deltaTime * PlayerCharacteristic.Limit / constitution.stress.cooldown;
            if (constitution.stress.ratio > PlayerCharacteristic.Limit) {
                onPlayerStressedOut?.Invoke();
                constitution.stress.ratio = 0;
            }
        }
    }
}
