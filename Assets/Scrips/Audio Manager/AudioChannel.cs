using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Audio Channel data", menuName = "ScriptableObjects/Audio/Audio Channel")]
public class AudioChannel : ScriptableObject
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string volumeKey;
    [SerializeField, Range(-80f, 20)] private float volumeRangeDB;
    [SerializeField, Range(0, 1)] private float volumeRangeNormal;

    public event Action<float> VolumeChanged;
    private void OnEnable()
    {
        VolumeChanged += UpdateVolume;
    }
    private void OnDisable()
    {
        VolumeChanged -= UpdateVolume;
    }

    public void UpdateMixerVolumenNormal(float newVolumeValue)
    {
        volumeRangeNormal = newVolumeValue;

        VolumeChanged?.Invoke(volumeRangeNormal);
    }
    private void UpdateVolume(float value)
    {
        volumeRangeDB = ToDecibels(value);
        mixer.SetFloat(volumeKey, ToDecibels(volumeRangeDB));
    }
    private float ToDecibels(float value)
    {
        //math.log10(float f) * 20
        return Mathf.Clamp(math.log10(value) * 20f, -80f, 20);
    }

    internal void UpdateMixerVolumenNormal()
    {
        throw new NotImplementedException();
    }
}