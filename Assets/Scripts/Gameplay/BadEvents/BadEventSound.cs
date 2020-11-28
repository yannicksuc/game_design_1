using Player;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.BadEvents {
    public class BadEventSound : ABadEvent {

        [SerializeField] private PlayerConstitution constitution = null;
        [SerializeField] private List<AudioClip> clips = new List<AudioClip>();
        [SerializeField] private AudioSource audioSource = null;
        [SerializeField] private float minPitch = 0.25f;
        [SerializeField] private float maxPitch = 1f;
        [SerializeField] private bool randomDirection = true;
        
        protected override void Awake() {
            base.Awake();
            if (clips.Count > 0) {
                audioSource.clip = clips[Random.Range(0, clips.Count)];
            }
            if (randomDirection) {
                audioSource.panStereo = Random.Range(-1f, 1f);
            }
            audioSource.Play();
        }

        private void Update() {
            audioSource.pitch = maxPitch - (maxPitch - minPitch) * (constitution.stress.Ratio / PlayerCharacteristic.Limit);
        }
    }
}
