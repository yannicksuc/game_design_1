using Player;
using UnityEngine;

namespace Gameplay.BadEvents {
    public class BadEventSound : ABadEvent {

        [SerializeField] private PlayerConstitution constitution = null;
        [SerializeField] private AudioSource audioSource = null;
        [SerializeField] private float minPitch = 0.25f;
        [SerializeField] private float maxPitch = 1f;
        [SerializeField] private bool randomDirection = true;

        private void Awake() {
            if (randomDirection) {
                audioSource.panStereo = Random.Range(-1f, 1f);
            }
        }

        private void Update() {
            audioSource.pitch = maxPitch - (maxPitch - minPitch) * (constitution.stress.Ratio / PlayerCharacteristic.Limit);
        }
    }
}
