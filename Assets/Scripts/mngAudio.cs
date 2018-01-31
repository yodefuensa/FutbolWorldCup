using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mngAudio : MonoBehaviour {

	public AudioSource musicSource;
	public AudioSource sfxSounds;
	public AudioClip[] musica;
	public static mngAudio instance;

	private void Awake (){
		if (mngAudio.instance == null)
			mngAudio.instance = this;
		else if (mngAudio.instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);

	}

	IEnumerator Start()
	{
		//musicSource = GetComponent<AudioSource> ();
		musicSource.Play ();
		yield return new WaitForSeconds (musicSource.clip.length);
		int n = Random.Range (0, 3);
		musicSource.clip = musica [n];
		musicSource.Play ();

	}

	public void playSfxClip(AudioClip sonidofx){
		sfxSounds.clip = sonidofx;
		sfxSounds.Play();
	}
}
