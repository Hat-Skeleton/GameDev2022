using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;
    public int level;
    public float currentXP;
    public float requiredXP;

    private float lerpTimer;
    private float delayTimer;

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
        UIController.instance.frontXpBar.fillAmount = currentXP / requiredXP;
        UIController.instance.backXpBar.fillAmount = currentXP / requiredXP;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXpUI();
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            GainExperienceFlatRate(20);
        }
        if(currentXP > requiredXP)
        {
            LevelUp();
        }
    }

    public void UpdateXpUI()
    {
        float xpFraction = currentXP / requiredXP;
        float FXP = UIController.instance.frontXpBar.fillAmount;
        if(FXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            UIController.instance.backXpBar.fillAmount = xpFraction;
            if(delayTimer > 0.5)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 4;
                UIController.instance.frontXpBar.fillAmount = Mathf.Lerp(FXP, UIController.instance.backXpBar.fillAmount, percentComplete);
            }
        }
    }

    public void GainExperienceFlatRate(float xpGained)
    {
        currentXP += xpGained;
        lerpTimer = 0f;
    }

    public void LevelUp()
    {
        level++;
        
        UIController.instance.frontXpBar.fillAmount = 0f;
        UIController.instance.backXpBar.fillAmount = 0f;
        currentXP = Mathf.RoundToInt(currentXP - requiredXP);
        requiredXP = Mathf.RoundToInt(requiredXP * 2.5f);
        UIController.instance.levelText.text = string.Format("Level : {0}", level);
        UIController.instance.levelUpScreen.SetActive(true);
        Time.timeScale = 0;
        PlayerController.instance.DisablePlay();
    }

}
