using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovXShooter : Enemy
{
    private float lifespan = 0;
    Vector3 pathToPlayer;
    public Projectile EnemyProjectile;
    
    public void UpdateLifespan() {
        lifespan += Time.deltaTime;
    }

    public override void Update()
    {
        if ((lifespan % 1.5) < 0.5 && ((lifespan + Time.deltaTime) % 1.5) > 0.5) {
            float enemyProjectileSpeed = 12f;
            for (int i = 0; i < 4; i++) {
                Vector3 direction = new Vector3(Mathf.Cos(Mathf.PI/2*i+Mathf.PI/4), Mathf.Sin(Mathf.PI/2*i+Mathf.PI/4), 0);
                var projectile = Instantiate(EnemyProjectile, transform.position+direction*0.4f, transform.rotation);
                projectile.Fire(enemyProjectileSpeed, direction);
            }   
        }
        UpdateLifespan();
    }
}
