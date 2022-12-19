using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ShakeScreen : MonoBehaviour
{
    public static ShakeScreen Instance { get; private set; }
    CinemachineVirtualCamera vcam;
    float shakeTime = 0;
    private void Awake()
    {
        Instance = this;
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTime = time;
    }

    private void Update()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
            if (shakeTime <= 0f)
            {
                ShakeCamera(0, 0);
            }
        }
    }
}
