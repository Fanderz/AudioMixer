using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderChanger : MonoBehaviour
{
    [SerializeField] private string _mixerName;
    [SerializeField] private AudioMixerGroup _mixer;

    public void ChangeVolume(float value)
    {
        _mixer.audioMixer.SetFloat(_mixerName, Mathf.Log10(value) * 20);
    }
}
