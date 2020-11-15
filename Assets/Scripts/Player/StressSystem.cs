using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Time;

namespace Player
{
    public class StressSystem : MonoBehaviour
    {
        [SerializeField] private PlayerConstitution constitution;
        void Start()
        {
            //constitution.stress.StepReached.AddListener(evolution => Debug.Log(evolution) );
        }

        // Update is called once per frame
        void Update()
        {
            if (constitution.stress.Ratio >= PlayerCharacteristic.Limit)
                return;
            constitution.stress.Ratio += deltaTime / constitution.stress.cooldown;
        }
    }
}
