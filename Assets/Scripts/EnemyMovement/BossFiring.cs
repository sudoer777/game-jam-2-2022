using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFiring : Enemy
{
    private float lifespan = 0;
    public Projectile EnemyProjectile;
    
    public void UpdateLifespan() {
        lifespan += Time.deltaTime;
    }

    public override void Update()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) >= 30f) {
            return;
        }
        if ((lifespan % 0.15) < 0.08 && ((lifespan + Time.deltaTime) % 0.15) > 0.08) {
            float enemyProjectileSpeed = 6f;
            for (int i = 0; i < 8; i++) {
                float angle = Mathf.PI/4*i+50*Mathf.Cos(lifespan/4);
                Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                var projectile = Instantiate(EnemyProjectile, transform.position+direction*0.4f, transform.rotation);
                projectile.Fire(enemyProjectileSpeed, direction);
            }   
        }
        UpdateLifespan();
        base.Update();
    }
}
