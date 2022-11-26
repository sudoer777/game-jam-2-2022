using System.Collections;
using System.Collections.Generic;
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
    private float stamina = 3.0f;
    private float staminaCap = 3.0f;
    public Projectile PlayerProjectile;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
            float playerProjectileSpeed = 10f;
            float angle = Mathf.Atan2((mouseRelPos.y-transform.position.y),(mouseRelPos.x-transform.position.x));//*180/Mathf.PI;
            Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            var projectile = Instantiate(PlayerProjectile, transform.position+direction*0.4f, transform.rotation);
            projectile.Fire(playerProjectileSpeed, direction);
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
            animator.Play("Idle");
        }

        if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            spriteRenderer.flipX = false;   
        }
    }
}