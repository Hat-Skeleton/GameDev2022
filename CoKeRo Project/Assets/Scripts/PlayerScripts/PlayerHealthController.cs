using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    static public int currentHealth = 5;
    static public int maxHeath = 5;

    public float iframes = 1f;
    private float iframeCount;

    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        

        

        

        UIController.instance.healthSlider.maxValue = maxHeath;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthBarText.text = string.Format("{0} / {1}",currentHealth,maxHeath);
    }

    // Update is called once per frame
    void Update()
    {
        if(iframeCount > 0)
        {
            iframeCount -= Time.deltaTime;

            if(iframeCount <= 0 )
            {
                PlayerController.instance.bodySr.color = new Color(PlayerController.instance.bodySr.color.r, PlayerController.instance.bodySr.color.g, PlayerController.instance.bodySr.color.b, 1f);
            }
        }
    }

    public void DamagePlayer()
    {
        if(iframeCount <= 0)
        {
            AudioManager.instance.PlaySFX(11);
            currentHealth--;

            iframeCount = iframes;

            PlayerController.instance.bodySr.color = new Color(PlayerController.instance.bodySr.color.r, PlayerController.instance.bodySr.color.g, PlayerController.instance.bodySr.color.b, 0.5f);

            if (currentHealth <= 0)
            {
                PlayerController.instance.gameObject.SetActive(false);
                UIController.instance.deathScreen.SetActive(true);

                AudioManager.instance.PlayGameOver();
            }

            UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healthBarText.text = string.Format("{0} / {1}", currentHealth, maxHeath);

            //
            AudioManager.instance.PlaySFX(8);
            
        }
        
    }

    public void MakeInv(float length)
    {
        iframeCount = iframes;
        PlayerController.instance.bodySr.color = new Color(PlayerController.instance.bodySr.color.r, PlayerController.instance.bodySr.color.g, PlayerController.instance.bodySr.color.b, 1f);
    }

    public void HealPlayer(int heal)
    {
        if (currentHealth != maxHeath)
        {
            currentHealth += heal;
        }

        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthBarText.text = string.Format("{0} / {1}", currentHealth, maxHeath);
    }

    public void UpdateHealth(int hpincrease)
    {
        maxHeath += hpincrease;

        currentHealth += hpincrease;
        UIController.instance.healthSlider.maxValue = maxHeath;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthBarText.text = string.Format("{0} / {1}", currentHealth, maxHeath);
    }
}
