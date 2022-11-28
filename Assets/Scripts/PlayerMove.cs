using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private int hor_input = 0;
    private int ver_input = 0;
    private float actualSpeed = 6.0f;
    private float playerSpeed = 8.0f;
    private float playerSprintSpeed = 14.0f;
    private float stamina = 2.0f;
    private float staminaCap = 2.0f;
    private float shotcooldown = 0f;
    private bool facingForward = false;
    public Projectile Projectile0;
    public Projectile Projectile1;
    public Projectile Projectile2;
    public Projectile Projectile3;
    public Projectile Projectile4;
    public AudioClip Projectile1Audio;
    public AudioClip Projectile2Audio;
    public AudioClip Projectile3Audio;
    public AudioClip Projectile4Audio;
    public AudioSource PlayerAudio;
    private Vector3 projectileOffset;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        projectileOffset = new Vector3(0.0f, 1.6f, 0.0f);
    }

    void Update()
    {
        if (DebuffMenu.paused || Pause.paused) {
            return;
        }

        var playerKeyUp = PlayerPrefs.HasKey("Up") ? (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up")) : KeyCode.W;
        var playerKeyDown = PlayerPrefs.HasKey("Down") ? (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down")) : KeyCode.S;
        var playerKeyLeft = PlayerPrefs.HasKey("Left") ? (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left")) : KeyCode.A;
        var playerKeyRight = PlayerPrefs.HasKey("Right") ? (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right")) : KeyCode.D;
        var playerKeySprint = PlayerPrefs.HasKey("Sprint") ? (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sprint")) : KeyCode.Space;

        var upPressed = Input.GetKey(playerKeyUp);
        var downPressed = Input.GetKey(playerKeyDown);
        var leftPressed = Input.GetKey(playerKeyLeft);
        var rightPressed = Input.GetKey(playerKeyRight);
        var sprintPressed = Input.GetKey(playerKeySprint);

        hor_input = 0;
        ver_input = 0;
        if (leftPressed) {
            hor_input--;
        } 
        if (rightPressed) {
            hor_input++;
        }
        if (upPressed) {
            ver_input++;
        } 
        if (downPressed) {
            ver_input--;
        }

        Vector3 move = new Vector3(hor_input, ver_input, 0);

        if (sprintPressed && stamina > 0.5f) {
            actualSpeed = playerSprintSpeed;
            stamina -= Time.deltaTime;
        } else {
            if (!sprintPressed || stamina <= 0f) {
                actualSpeed = playerSpeed;
                if (stamina < staminaCap) {
                    stamina += Time.deltaTime;
                } 
                if (stamina > staminaCap) {
                    stamina = staminaCap;
                }
            } else {
                if (actualSpeed != playerSpeed) {
                    stamina -= Time.deltaTime;
                } else {
                    stamina += Time.deltaTime;
                }
            }
        }
        rb.velocity = move*actualSpeed;

        StaminaBar.Instance.SetStamina(stamina/staminaCap);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 mouseRelPos = Camera.main.ScreenToWorldPoint(mousePos);
            
            float ang = Mathf.Atan2((mouseRelPos.y-transform.position.y-projectileOffset.y),(mouseRelPos.x-transform.position.x));

            facingForward = ang >= -2.25f && ang <= -.75f;
            spriteRenderer.flipX = Math.Abs(ang) >= 1.5f;

            Debug.unityLogger.Log(ang);
            if (shotcooldown <= 0) {
                if (Player.Instance.gun == 0) {
                    float playerProjectileSpeed = 48f;
                    Vector3 direction = new Vector3(Mathf.Cos(ang), Mathf.Sin(ang), 0);
                    var projectile = Instantiate(Projectile0, transform.position+direction*0.4f + projectileOffset, transform.rotation);
                    projectile.Fire(playerProjectileSpeed, direction);
                    shotcooldown = 0.2f;
                } else if (Player.Instance.gun == 1) {
                    float playerProjectileSpeed = 36f;
                    float angle = ang-2/5;
                    for (float i = -2; i < 2.1f; i += 1) {
                        Vector3 direction = new Vector3(Mathf.Cos(angle+i/3), Mathf.Sin(angle+i/3), 0);
                        var projectile = Instantiate(Projectile1, transform.position+direction*0.3f + projectileOffset, transform.rotation);
                        projectile.Fire(playerProjectileSpeed, direction);
                        shotcooldown = 0.4f;
                    }
                    PlayerAudio.clip = Projectile1Audio;
                } else if (Player.Instance.gun == 2) {
                    for (float i = -2; i < 2.1f; i += 1) {
                        float playerProjectileSpeed = 36f+8*i;
                        Vector3 direction = new Vector3(Mathf.Cos(ang), Mathf.Sin(ang), 0);
                        var projectile = Instantiate(Projectile2, transform.position+direction*0.3f + projectileOffset, transform.rotation);
                        projectile.Fire(playerProjectileSpeed, direction);
                        shotcooldown = 0.3f;
                    }
                    PlayerAudio.clip = Projectile2Audio;
                } else if (Player.Instance.gun == 3) {
                    for (float i = -1; i < 2.1f; i += 1) {
                        for (float j = -1; j < 1.1f; j += 1) {
                            float playerProjectileSpeed = 40f+8*i;
                            Vector3 direction = new Vector3(Mathf.Cos(ang+j/2), Mathf.Sin(ang+j/2), 0);
                            var projectile = Instantiate(Projectile3, transform.position+direction*0.3f + projectileOffset, transform.rotation);
                            projectile.Fire(playerProjectileSpeed, direction);
                            shotcooldown = 0.3f;
                        }
                    }
                    PlayerAudio.clip = Projectile3Audio;
                } else if (Player.Instance.gun == 4) {
                    float playerProjectileSpeed = 44f;
                    Vector3 direction = new Vector3(Mathf.Cos(ang), Mathf.Sin(ang), 0);
                    var projectile = Instantiate(Projectile4, transform.position+direction*0.3f + projectileOffset, transform.rotation);
                    projectile.Fire(playerProjectileSpeed, direction);
                    shotcooldown = 0.5f;
                    PlayerAudio.clip = Projectile4Audio;
                }
                PlayerAudio.Play();
            }
        }
        if (shotcooldown > 0) {
            shotcooldown -= Time.deltaTime;
        }
        
        
        if (leftPressed || rightPressed)
        {
            animator.Play("Walk");
        }
        else if (upPressed)
        {
            animator.Play("BackWalk");
        }
        else if (downPressed)
        {
            animator.Play("FrontWalk");
        }
        else
        {
            if (facingForward)
            {
                animator.Play("FrontIdle");
            }
            else
            {
                animator.Play("Idle");
            }
        }
        
        spriteRenderer.flipX = (leftPressed && !rightPressed) || (spriteRenderer.flipX && (leftPressed && rightPressed || !rightPressed));
        facingForward = downPressed || (facingForward && !leftPressed && !upPressed && !rightPressed);
    }

    public void DebuffStamina() {
        staminaCap *= 0.8f;
        if (stamina > staminaCap) {
            stamina = staminaCap;
        }
    } 
}