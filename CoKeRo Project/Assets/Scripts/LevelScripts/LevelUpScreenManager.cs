using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelUpScreenManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void HealthUp()
    {
        PlayerHealthController.instance.UpdateHealth(1);
        DisableScreen();
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
