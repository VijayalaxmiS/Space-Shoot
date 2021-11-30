using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetSliderLevel (float volume)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(volume) * 20);
    }
   
}
