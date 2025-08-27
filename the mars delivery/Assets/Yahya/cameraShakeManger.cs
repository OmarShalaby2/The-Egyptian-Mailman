using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraShakeManger : MonoBehaviour
{
    public static cameraShakeManger Instance;
    public float force = 1f;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }
    public void cameraShake(CinemachineImpulseSource source)
    {
        source.GenerateImpulseWithForce(force);
    }
}
