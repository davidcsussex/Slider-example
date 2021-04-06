using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This script uses "PlayerPrefs" to permanently store the music volume

//https://answers.unity.com/questions/1325056/how-to-use-playerprefs-2.html
public class FrontendScript : MonoBehaviour
{
    // Start is called before the first frame update

    // The frontend gameobject uses this script
    // This script can store player lives, score, sound effect volume etc


    // reference to the music slider - set this up in the Unity editor
    public GameObject musicSlider;

    void Start()
    {
        float musicVol;

        // if the musicvolume key exists, read it    
        if( PlayerPrefs.HasKey("musicvolume"))
        {
            musicVol = PlayerPrefs.GetFloat("musicvolume");
        }
        else
        {
            // initial music volume when run for the very first time
            musicVol = 0.5f;
        }
        
        // set the slider to the stored value
        musicSlider.GetComponent<Slider>().value = musicVol;   

        // set the music to play at the store value
        AudioManager.instance.Play("music", musicVol );

        // permanently store the music volume value
        PlayerPrefs.SetFloat("musicvolume", musicVol);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
