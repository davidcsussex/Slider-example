using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    

    // this method is called every time the music slider is moved
    public void MusicSliderChanged()
    {
        float value = GetComponent<Slider>().value;   
        print("slider=" + value);

        // store the slider's value in a permanent storage
        // Google "PlayerPrefs" to see how it works

        // permanently store the music slider volume
        PlayerPrefs.SetFloat("musicvolume",value);

        // adjust the music volume to the new level
        AudioManager.instance.SetVolume("music", value );
    }

    // Load a scene. The name is specified in the editor
    public void LoadScene(string level)
    { 
         SceneManager.LoadScene(level);
    }

}
