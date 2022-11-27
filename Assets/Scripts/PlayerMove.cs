using System.Collections;
using System.Collections.Generic;
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
    private float playerSpeed = 6.0f;
    private float playerSprintSpeed = 12.0f;
    private float stamina = 2.0f;
    private float staminaCap = 2.0f;
    private float shotcooldown = 0f;
    private bool facingForward = false;
    public Projectile PlayerProjectile;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (DebuffMenu.paused || Pause.paused) {
            return;
        }
        hor_input = 0;
        ver_input = 0;
        if (Input.GetKey("a")) {
            hor_input--;
        } 
        if (Input.GetKey("d")) {
            hor_input++;
        }
        if (Input.GetKey("w")) {
            ver_input++;
        } 
        if (Input.GetKey("s")) {
            ver_input--;
        }

        Vector3 move = new Vector3(hor_input, ver_input, 0);

        if (Input.GetKeyDown("space") && stamina > 0.5f) {
            actualSpeed = playerSprintSpeed;
            stamina -= Time.deltaTime;
        } else {
            if (!Input.GetKey("space") || stamina <= 0f) {
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
            if (shotcooldown <= 0) {
                if (Player.Instance.gun == 0) {
                    float playerProjectileSpeed = 12f;
                    float angle = Mathf.Atan2((mouseRelPos.y-transform.position.y),(mouseRelPos.x-transform.position.x));//*180/Mathf.PI;
                    Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                    var projectile = Instantiate(PlayerProjectile, transform.position+direction*0.4f, transform.rotation);
                    projectile.Fire(playerProjectileSpeed, direction);
                    shotcooldown = 0.2f;
                } else if (Player.Instance.gun == 1) {
                    float playerProjectileSpeed = 9f;
                    float angle = Mathf.Atan2((mouseRelPos.y-transform.position.y),(mouseRelPos.x-transform.position.x))-2/5;
                    for (float i = -2; i < 2.1f; i += 1) {
                        Vector3 direction = new Vector3(Mathf.Cos(angle+i/3), Mathf.Sin(angle+i/3), 0);
                        var projectile = Instantiate(PlayerProjectile, transform.position+direction*0.3f, transform.rotation);
                        projectile.Fire(playerProjectileSpeed, direction);
                        shotcooldown = 0.4f;
                    }
                } else if (Player.Instance.gun == 2) {
                    float angle = Mathf.Atan2((mouseRelPos.y-transform.position.y),(mouseRelPos.x-transform.position.x));
                    for (float i = -2; i < 2.1f; i += 1) {
                        float playerProjectileSpeed = 9f+2*i;
                        Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                        var projectile = Instantiate(PlayerProjectile, transform.position+direction*0.3f, transform.rotation);
                        projectile.Fire(playerProjectileSpeed, direction);
                        shotcooldown = 0.3f;
                    }
                } else if (Player.Instance.gun == 3) {
                    for (float i = -1; i < 2.1f; i += 1) {
                        for (float j = -1; j < 1.1f; j += 1) {
                            float playerProjectileSpeed = 10f+2*i;
                            float angle = Mathf.Atan2((mouseRelPos.y-transform.position.y),(mouseRelPos.x-transform.position.x));
                            Vector3 direction = new Vector3(Mathf.Cos(angle+j/2), Mathf.Sin(angle+j/2), 0);
                            var projectile = Instantiate(PlayerProjectile, transform.position+direction*0.3f, transform.rotation);
                            projectile.Fire(playerProjectileSpeed, direction);
                            shotcooldown = 0.3f;
                        }
                    }
                } else if (Player.Instance.gun == 4) {
                    float playerProjectileSpeed = 11f;
                    float angle = Mathf.Atan2((mouseRelPos.y-transform.position.y),(mouseRelPos.x-transform.position.x));
                    Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                    var projectile = Instantiate(PlayerProjectile, transform.position+direction*0.3f, transform.rotation);
                    projectile.Fire(playerProjectileSpeed, direction);
                    shotcooldown = 0.5f;
                }
            }
        }
        if (shotcooldown > 0) {
            shotcooldown -= Time.deltaTime;
        }
        
        
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            animator.Play("Walk");
        }
        else if (Input.GetKey("w"))
        {
            animator.Play("BackWalk");
        }
        else if (Input.GetKey("s"))
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
        
        spriteRenderer.flipX = (Input.GetKey("a") && !Input.GetKey("d")) || (spriteRenderer.flipX && (Input.GetKey("a") && Input.GetKey("d") || !Input.GetKey("d")));
        facingForward = Input.GetKey("s") || (facingForward && !Input.GetKey("a") && !Input.GetKey("w") && !Input.GetKey("d"));
    }

    public void DebuffStamina() {
        staminaCap *= 0.8f;
        if (stamina > staminaCap) {
            stamina = staminaCap;
        }
    } 
}