using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

// to do - watch this brackey's tutorial and implement the audio manager
//https://www.youtube.com/watch?v=6OT43pvUyfY

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;
	public AudioMixerGroup mixerGroup;

	// this is the list of sounds we have defined in the editor
	public Sound[] soundList;


	void Awake()
	{
		

		if (instance == null)
		{
			// if instance is null, store a reference to this instance
			instance = this;
			DontDestroyOnLoad(gameObject);
			//print("dont destroy");
		}
		else
		{		
			// Another instance of this gameobject has been made so destroy it
			// as we already have one
			//print("do destroy");
			Destroy(gameObject);

		}

		foreach (Sound sound in soundList )
		{
			// add an Audiosource component to the game objects
			sound.source = gameObject.AddComponent<AudioSource>();
			sound.source.clip = sound.clip;
			sound.source.outputAudioMixerGroup = mixerGroup;
		}



	}

	
	public void Play(string sound, float volume )
	{
		
		Sound s = Array.Find(soundList, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = volume;
		s.source.pitch = s.pitch;

		s.source.Play();
	}


	public void SetVolume( string sound, float volume )
	{
		Sound s = Array.Find(soundList, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.source.volume = volume;
	}




}
