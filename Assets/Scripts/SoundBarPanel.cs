using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundBarPanel : MonoBehaviour
{
    [SerializeField] private SliderChanger[] _allSliders;
    [SerializeField] private ToggleChanger _toggleChanger;

    private void Awake()
    {
        for (int i = 0; i < _allSliders.Length; i++)
        {
            if (_allSliders[i].TryGetComponent(out Slider slider))
                slider.onValueChanged.AddListener(_allSliders[i].ChangeVolume);
        }

        _toggleChanger.TryGetComponent(out Toggle toggleChanger);
        toggleChanger.onValueChanged.AddListener(_toggleChanger.DisableVolume);
    }
}
