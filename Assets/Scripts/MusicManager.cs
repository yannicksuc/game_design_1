using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : IManager<MusicManager> {

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float transitionTime = 1f;

    public void ChangeMusic(AudioClip clip = null) {
        if (audioSource.clip != clip) {
            StartCoroutine(StartTransition(clip));
        }
    }

    private IEnumerator StartTransition(AudioClip clip = null) {
        float currentTime = 0;
        float startVolume = audioSource.volume;
        if (audioSource.clip) {
            while (currentTime < transitionTime) {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(startVolume, 0, currentTime / transitionTime);
                yield return null;
            }
        }
        audioSource.volume = 0;
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
        currentTime = 0;
        if (audioSource.clip) {
            while (currentTime < transitionTime) {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(0, startVolume, currentTime / transitionTime);
                yield return null;
            }
        }
        audioSource.volume = startVolume;
    }
}
