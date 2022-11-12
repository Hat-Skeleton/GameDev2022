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
    public GameObject levelUpScreen;

    [Header("HealthBar")]
    public Slider healthSlider;
    public TMP_Text healthBarText;

    [Header("XpBar")]
    public Image frontXpBar;
    public Image backXpBar;
    public TMP_Text levelText;

    public Image fade;
    public float fadeSpeed;

    private bool fadeToBlack;
    private bool fadeToAlpha;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fadeToAlpha = true;
        fadeToBlack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToAlpha)
        {
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, Mathf.MoveTowards(fade.color.a, 0f, fadeSpeed * Time.deltaTime));
            if(fade.color.a == 0f)
            {
                fadeToAlpha = false;
            }
        }
        if (fadeToBlack)
        {
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, Mathf.MoveTowards(fade.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fade.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }
    }

    public void startFadeToBlack()
    {
        fadeToBlack = true;
        fadeToAlpha = false;
    }
}
