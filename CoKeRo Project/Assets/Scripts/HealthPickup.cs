using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(PlayerHealthController.currentHealth != PlayerHealthController.maxHeath)
            {
                PlayerHealthController.instance.HealPlayer(healAmmount);
                Destroy(gameObject);
                AudioManager.instance.PlaySFX(7);
            }
            
        }
    }
}
