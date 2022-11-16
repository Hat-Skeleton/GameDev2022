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

    public float additionMultiplier = 300;
    public float powerMultiplier = 2;
    public float divisionMultiplier = 7;

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
        UIController.instance.frontXpBar.fillAmount = currentXP / requiredXP;
        UIController.instance.backXpBar.fillAmount = currentXP / requiredXP;
        requiredXP = CalculateRequiredXp();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXpUI();
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            GainExperienceFlatRate(5);
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
        currentXP += requiredXP/xpGained;
        lerpTimer = 0f;
    }

    public void LevelUp()
    {
        level++;
        
        UIController.instance.frontXpBar.fillAmount = 0f;
        UIController.instance.backXpBar.fillAmount = 0f;
        currentXP = Mathf.RoundToInt(currentXP - requiredXP);
        requiredXP = CalculateRequiredXp();
        UIController.instance.levelText.text = string.Format("Level : {0}", level);
        UIController.instance.levelUpScreen.SetActive(true);
        Time.timeScale = 0;
        PlayerController.instance.DisablePlay();
    }

    public int CalculateRequiredXp()
    {
        int solveForRequiredXp = 0;
        for(int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequiredXp += (int)Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        return solveForRequiredXp / 4;
    }
}
