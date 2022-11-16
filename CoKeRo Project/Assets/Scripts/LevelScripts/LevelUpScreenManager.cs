using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelUpScreenManager instance;

    [Header("LevelUp Buttons")]
    public Button weaponUp;
    public Button speedUp;
    public Button healthUp;

    [Header("Bullet Images")]
    public Image bulletimage;

    private int boostlvl;
    private int amtBullets;
    private int bulletlvl;

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

    public void Start()
    {
        amtBullets = PlayerController.instance.bullets.Length;
        bulletlvl = 1;
        Debug.Log(amtBullets);
    }
    public void OnEnable()
    {
    }
    public void HealthUp()
    {
        PlayerHealthController.instance.UpdateHealth(1);
        DisableScreen();
    }

    public void DamageUp()
    {
        if (amtBullets >= bulletlvl)
        {
            PlayerController.instance.LevelBullet();
            bulletlvl++;
            DisableScreen();
            if (amtBullets == bulletlvl + 1)
            {
                weaponUp.interactable = false;
            }
            else
            {
                bulletimage.sprite = PlayerController.instance.bullets[bulletlvl + 1].GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

    public void SpeedUp()
    {
        PlayerController.instance.IncreaseSpeed();
        DisableScreen();
        boostlvl++;
        if(boostlvl == 8)
        {
            speedUp.interactable = false;
        }
    }

    public void EnableScreen()
    {
        UIController.instance.levelUpScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void DisableScreen()
    {
        UIController.instance.levelUpScreen.SetActive(false);
        Time.timeScale = 1;
        PlayerController.instance.DisablePlay();
    }

}
