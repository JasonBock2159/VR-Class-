using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CoreFeatures : MonoBehaviour
{
    /**
    *We need a common way to access this code outside of this class
    *Create a property value- "encapsulation"
    *Properties have ACCESSORS to basically define the properties
    *GET Acessor (READ) return encapsulated variable.
    *SET Accessor (WRITE) allocates new values to fields
     **/
   
    public bool AudioSFXSourceCreated {  get; set; }

    [field: SerializeField]
    public AudioClip AudioClipOnStart { get; set; }

    [field: SerializeField]
    public AudioClip AudioClipOnEnd { get; set; }

    private AudioSource audioSource;

    public FeaturedUsage featuredUsage = FeaturedUsage.Once;

    protected virtual void Awake()
    {
        MakeAudioSFXSource();
    }


    private void MakeAudioSFXSource()
    {
        audioSource = GetComponent<AudioSource>();

        //if this is equal to null, create it right here

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        //Regardless of null or not, we still need to make sure this is true on awake
        AudioSFXSourceCreated = true;
    }

    //Audio Play Commands
    protected void PlayOnStart()
    {
        if(AudioSFXSourceCreated && AudioClipOnStart != null)
        {
            audioSource.clip = AudioClipOnStart;
            audioSource.Play();
        }
        
    }

    protected void PlayOnEnd()
    {
        if (AudioSFXSourceCreated && AudioClipOnEnd != null)
        {
            audioSource.clip = AudioClipOnEnd;
            audioSource.Play();
        }

    }
}
