using Cinemachine;
using Player;
using UnityEngine;

namespace Gameplay.BadEvents
{
    public class BadEventCameraRotate : ABadEvent {

        [SerializeField] private PlayerConstitution constitution = null;
        [SerializeField] private CinemachineVirtualCamera _camera = null;
        [SerializeField] private float minRotation = 0f;
        [SerializeField] private float maxRotation = 1f;
        private CinemachineBasicMultiChannelPerlin noise = null;

        void Awake() {
            noise = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        private void Update() {
            _camera.m_Lens.Dutch = minRotation + (maxRotation - minRotation) * (constitution.stress.Ratio / PlayerCharacteristic.Limit);
            noise.m_AmplitudeGain = minRotation + (maxRotation - minRotation) * (constitution.stress.Ratio / PlayerCharacteristic.Limit);
        }

        private void OnDestroy() {
            noise.m_FrequencyGain = 0;
            noise.m_AmplitudeGain = 0;
        }
    }
}
