using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour {

    [SerializeField] private AudioClip clip = null;
    
    void Awake() {
        if (MusicManager.Instance)
            MusicManager.Instance.ChangeMusic(clip);
    }
}
