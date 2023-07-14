using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneAudioPlay : MonoBehaviour
{
    public static OneAudioPlay instance;
    public List<AudioSource> listAudio;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    public void StopOtherAudio(AudioSource audioPlay)
    {
        foreach (var item in listAudio)
        {
            if (audioPlay==item)
            {
                continue;
            }
            item.Stop();
        }
    }
}
