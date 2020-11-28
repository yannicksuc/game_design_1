using Cinemachine;
using Player;
using UnityEngine;

namespace Gameplay.BadEvents
{
    public class BadEventCameraShake : ABadEvent {

        [SerializeField] private PlayerConstitution constitution = null;
        [SerializeField] private float minShake = 0f;
        [SerializeField] private float maxShake = 1f;
        private CinemachineBasicMultiChannelPerlin noise = null;

        protected override void Awake() {
            base.Awake();
            noise = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        private void Update() {
            noise.m_FrequencyGain = minShake + (maxShake - minShake) * (constitution.stress.Ratio / PlayerCharacteristic.Limit);
            noise.m_AmplitudeGain = minShake + (maxShake - minShake) * (constitution.stress.Ratio / PlayerCharacteristic.Limit);
        }

        private void OnDestroy() {
            noise.m_FrequencyGain = 0;
            noise.m_AmplitudeGain = 0;
        }
    }
}
