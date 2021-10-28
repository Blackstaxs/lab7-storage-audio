using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController aCtrl;
    public GameObject bgMusic1;
    public GameObject[] songs;
    int currentSong = 0;
    public AudioSource sfxSrc;
    private AudioSource levelMusic;
    private AudioSource musicList;
    // Start is called before the first frame update
    public void Awake() 
    { if (aCtrl == null) 
        { 
            levelMusic = bgMusic1.GetComponent<AudioSource>(); 
            levelMusic.loop = true;
            aCtrl = this;
            musicList = songs[0].GetComponent<AudioSource>();
        } 
    }

    public void PlaySFX() 
    { 
        aCtrl.sfxSrc.Play(); 
    }
    public void PlayNext()
    {
        musicList = songs[currentSong].GetComponent<AudioSource>();
        if (musicList.isPlaying)
        {
            musicList.Stop();
        }
        currentSong++;
        if (currentSong >= songs.Length)
        {
            currentSong = 0;
        }
        Debug.Log(songs[currentSong]);
        musicList = songs[currentSong].GetComponent<AudioSource>();
        musicList.Play();
    }
    public void StopMusic() 
    { 
        musicList.Stop(); 
    }
    public void PauseMusic() 
    { 
        musicList.Pause(); 
    }
    public void PlayMusic()
    {
        musicList.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
