using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class mngOpciones : MonoBehaviour {

    public Dropdown resolution;
    public Toggle fullscreen;
    public Toggle mute;
    public AudioSource audiosource;

    private Resolution[] resolutions;
    private bool FullScreen;
    private static bool MuteSound;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void Awake()
    {
        resolutions = Screen.resolutions;
        fullscreen.isOn = FullScreen = Screen.fullScreen;
        //mute.isOn = MuteSound = audiosource.mute;

        for (int i = 0; i < resolutions.Length; i++)
        {
            resolution.options.Add(new Dropdown.OptionData(resolutions[i].width + "x" + resolutions[i].height + "x" + resolutions[i].refreshRate));

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                resolution.value = i;
        }
    }

    public void changeResolution()
    {
        string[] splitText = resolution.options[resolution.value].text.Split('x');
        Screen.SetResolution(int.Parse(splitText[0]), int.Parse(splitText[1]), Screen.fullScreen, int.Parse(splitText[2]));
    }

    public void changeFullscreen()
    {
        FullScreen = Screen.fullScreen = fullscreen.isOn;
    }

    public void changeMute()
    {
        MuteSound = audiosource.mute = mute.isOn;
    }
}
