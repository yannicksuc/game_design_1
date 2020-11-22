using Cinemachine;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    [SerializeField] private PlayerConstitution constitution = null;
    [SerializeField] private CinemachineVirtualCamera _camera = null;
    [SerializeField] [Range(1, 179)] private float maxFOV = 60;
    [SerializeField] [Range(1, 179)] private float minFOV = 10;

    void Update() {
        _camera.m_Lens.FieldOfView = maxFOV - (maxFOV - minFOV) * (constitution.stress.Ratio / PlayerCharacteristic.Limit);
    }
}
