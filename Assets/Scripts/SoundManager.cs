using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> myList = new List<AudioClip>();
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayAudio(int audioID, float audioVol)
    {
        source.PlayOneShot(myList[audioID], audioVol);
    }
}