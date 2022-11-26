using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovLeaper : Enemy
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public int movespeed; 
    private float lifespan = 0;
    Vector3 pathToPlayer;
    
    public override void Update()
    {
        if ((lifespan % 2) < 1.5 && ((lifespan + Time.deltaTime) % 2) > .75)
        {
            animator.Play("Ready");
            pathToPlayer = (Player.Instance.transform.position - this.transform.position).normalized;
            spriteRenderer.flipX = pathToPlayer.x < 0;
        }
        UpdateLifespan();
        if ((lifespan % 2) > 1.5) {
            rb.velocity = pathToPlayer*movespeed;
            animator.Play("Charge");
        }

        if ((lifespan % 2) < .75)
        {
            animator.Play("Idle");
        }
    }
    public void UpdateLifespan() {
        lifespan += Time.deltaTime;
    }
}
