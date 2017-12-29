using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTest : MonoBehaviour
{
	public AudioSource audioSource;
	AudioClip[] audioClips;
	Composer composer;

	float cooldownTime = 0.5f;
	float cooldown = 0.5f;
	bool isPlaying;

	// Use this for initialization
	void Start ()
	{
		InitializeAudioClips();
	}

	void InitializeAudioClips()
	{
		audioClips = Resources.LoadAll<AudioClip>("");
		composer = new Composer(audioClips.Length);

		foreach(AudioClip ac in audioClips)
			composer.AddMelody(ac.name);
	}

	void Update()
	{
		if(isPlaying == true)
		{
			if(cooldown <= 0f)
			{
				cooldown = cooldownTime;
				isPlaying = false;
			}
			else
				cooldown -= Time.deltaTime;
		}	
	}

	public void Button_Clicked()
	{
		if(isPlaying == false)
		{
			int nextMelody = composer.NextMelody();
			audioSource.PlayOneShot(audioClips[nextMelody], 1f);

			//isPlaying = true;
		}
	}
}
