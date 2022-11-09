using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class AudioManager : MonoBehaviour
    
{
    public AudioSource levelMusic, gameOverMusic, winMusic;
    public static AudioManager instance;
    public AudioSource[] sfx;

    public void Awake()
    {
           instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameOver()
    {
        levelMusic.Stop();
        gameOverMusic.Play();
    }

    public void PlayLevelWin()
    {
        levelMusic.Stop();
        winMusic.Play();
    }

    public void PlaySFX(int sfxToPLay)
    {
        sfx[sfxToPLay].Stop();
        sfx[sfxToPLay].Play();

    }
}
