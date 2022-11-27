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

        var playerKeyUp = PlayerPrefs.HasKey("Up") ? PlayerPrefs.GetString("Up") : "w";
        var playerKeyDown = PlayerPrefs.HasKey("Down") ? PlayerPrefs.GetString("Down") : "s";
        var playerKeyLeft = PlayerPrefs.HasKey("Left") ? PlayerPrefs.GetString("Left") : "a";
        var playerKeyRight = PlayerPrefs.HasKey("Right") ? PlayerPrefs.GetString("Right") : "d";
        var playerKeySprint = PlayerPrefs.HasKey("Sprint") ? PlayerPrefs.GetString("Sprint") : "space";

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
            if (shotcooldown <= 0) {
                Vector3 mousePos = Input.mousePosition;
                Vector3 mouseRelPos = Camera.main.ScreenToWorldPoint(mousePos);
                float playerProjectileSpeed = 10f;
                float angle = Mathf.Atan2((mouseRelPos.y-transform.position.y),(mouseRelPos.x-transform.position.x));//*180/Mathf.PI;
                Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                var projectile = Instantiate(PlayerProjectile, transform.position+direction*0.4f, transform.rotation);
                projectile.Fire(playerProjectileSpeed, direction);
                shotcooldown = 0.2f;
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