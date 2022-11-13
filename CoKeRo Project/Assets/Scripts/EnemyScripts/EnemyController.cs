using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    public float rangeToChase;
    private Vector3 moveDirection;

    public Animator anim;

    public int health = 150;

    public bool shouldShoot;

    public GameObject bullet;

    public Transform firePoint;

    public float enemyFireRate;
    private float fireCounter;

    public float shootRange;

    public SpriteRenderer sr;

    public bool shouldDropItem;
    public GameObject[] itemsToDrop;
    public float dropPercent;

    public float xpAmmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sr.isVisible && PlayerController.instance.gameObject.activeInHierarchy)
        {
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToChase)
            {
                moveDirection = PlayerController.instance.transform.position - transform.position;
            }
            else
            {
                moveDirection = Vector3.zero;
            }


            moveDirection.Normalize();

            rb.velocity = moveDirection * moveSpeed;



            if (shouldShoot && Vector3.Distance(transform.position, PlayerController.instance.transform.position) < shootRange)
            {
                fireCounter -= Time.deltaTime;
                if (fireCounter <= 0)
                {
                    fireCounter = enemyFireRate;
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    AudioManager.instance.PlaySFX(13);
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    public void DamageEmeny(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
            AudioManager.instance.PlaySFX(2);

            LevelSystem.instance.currentXP += xpAmmount;
            //drop items
            if(shouldDropItem)
            {
                float dropChance = Random.Range(0f, 100f);

                if(dropChance < dropPercent)
                {
                    int randomItem = Random.Range(0, itemsToDrop.Length);

                    Instantiate(itemsToDrop[randomItem], transform.position, transform.rotation);  
                }
            }

        }
    }
}
