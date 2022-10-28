using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [Header("Screens")]
    public GameObject deathScreen;
    public GameObject pauseScreen;

    [Header("HealthBar")]
    public Slider healthSlider;
    public TMP_Text healthBarText;

    [Header("XpBar")]
    public Image frontXpBar;
    public Image backXpBar;
    public TMP_Text levelText;

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
}
