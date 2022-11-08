using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 7.5f;
    public Rigidbody2D rb;
    public GameObject bulletHit;
    public GameObject bulletHitEnemy;

    public int bulletDamage = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioMananger.instance.PlayFX(4);
        if (other.tag == "Enemy")
        {
            Instantiate(bulletHitEnemy, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(bulletHit, transform.position, transform.rotation);
        }
        Destroy(gameObject);

        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DamageEmeny(bulletDamage);
        }
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
