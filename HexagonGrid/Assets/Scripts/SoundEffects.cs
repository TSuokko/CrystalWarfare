using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SoundEffects : MonoBehaviour {

    public AudioClip[] sounds;
    AudioSource speaker;

    // Use this for initialization
    void Start()
    {
        speaker = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(int track)
    {
        speaker.clip = sounds[track];
        speaker.Play();
    }
}
