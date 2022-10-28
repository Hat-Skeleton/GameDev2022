using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    private Vector2 moveInput;

    public Rigidbody2D rb;

    public Transform gunArm;

    private Camera cam;

    public Animator animator;

    public GameObject bulletToFire;
    public Transform firePoint;

    public float fireRate;
    private float shotCounter;

    public SpriteRenderer bodySr;

    private float activeMoveSpeed;
    public float dashSpeed = 8f, dashLength = 0.5f, dashCooldwon = 1f, dashIframes = 0.5f;
    private float dashCounter, dashCoolCounter;
    public bool isPaused;

    private void Awake()
    {
        instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        //transform.position += new Vector3(moveInput.x * Time.deltaTime * moveSpeed, moveInput.y * Time.deltaTime * moveSpeed);
        rb.velocity = moveInput * activeMoveSpeed;

        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = cam.WorldToScreenPoint((transform.localPosition));

        if(mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
            gunArm.localScale = new Vector3(-1f,-1f,1f);
        }
        else
        {
            transform.localScale = Vector3.one;
            gunArm.localScale = Vector3.one;
        }

        //rotate gun arm
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0, 0, angle);


        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            shotCounter = fireRate;
        }

        if (Input.GetMouseButton(0))
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                shotCounter = fireRate;
            }
        }

        
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            if(dashCoolCounter <= 0 && dashCounter<= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;

                animator.SetTrigger("Dash");
                PlayerHealthController.instance.MakeInv(dashIframes);
            }
            
        }

        //Switch Mode of pause Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseState();
        }

        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if(dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldwon;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        if (moveInput != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    //flips pausestate
    public void PauseState()
    {
        isPaused = !isPaused;
        UIController.instance.pauseScreen.SetActive(isPaused);
        Time.timeScale = Convert.ToInt32(!isPaused);
    }
}
