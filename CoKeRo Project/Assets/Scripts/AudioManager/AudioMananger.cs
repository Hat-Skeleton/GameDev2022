using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMananger : MonoBehaviour
{
    public static AudioMananger instance;
    public AudioSource levelMusic, gameOverMusic,winMusic;
    public AudioSource[] fx;
    private void Awake()
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

    public void PlayGameWin()
    {
        levelMusic.Stop();
        winMusic.Play();
    }

    public void PlayFX(int fxToPlay)
    {
        fx[fxToPlay].Stop();
        fx[fxToPlay].Play();
    }
}
