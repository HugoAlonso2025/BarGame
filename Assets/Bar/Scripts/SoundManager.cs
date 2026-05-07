using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Variable declaration
    public static SoundManager instance;

    AudioSource audioSource;
    public float audioPitch;

    private void Awake() //Method that works before the program is working
    {
        audioSource = GetComponent<AudioSource>(); //Searchs the component
    }

    private void Start()
    {
        audioSource.pitch = audioPitch;
    }

    public void PlaySound(AudioClip audio) //Method that plays an audio given 
    {
        float random;
        random = Random.Range(0.8f, 1.2f);
        audioSource.pitch = random;
        audioSource.PlayOneShot(audio);
    }
}
