using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;
	public static AudioManager instance;
	[Range(0f, 1f)]
	public float backgroundMusicVolume;

	// Use this for initialization
	void Awake () {

		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	void Start() {
		ToggleMuteSong ("DarkworldTheme", true);
		PlayOneShot ("OverworldTheme");
		PlayOneShot ("DarkworldTheme");
	}
	
	public void Play (string name) {
		//Search in "sounds" array for a sound, where sound.name == name
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning ("Sound: " + name + " not found!");
			return;
		}
		s.source.Play ();
	}

	//For playing songs at the same time
	public void PlayOneShot (string name) {
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning ("Sound: " + name + " not found!");
			return;
		}
		s.source.PlayOneShot(s.source.clip);
	}

	//if mute is true, the song "name" will be muted
	//if mute is false, the song "name" will be unmuted
	public void ToggleMuteSong (string name, bool mute) {
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning ("Sound: " + name + " not found!");
			return;
		}

		if (mute) {
			s.source.volume = 0;
		} else {
			s.source.volume = backgroundMusicVolume;
		}
	}
		
}
