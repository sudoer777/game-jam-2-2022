using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovVShooter : Enemy
{
    private float lifespan = 0;
    Vector3 playerPos;
    Vector3 direction;
    public Projectile EnemyProjectile;
    public void UpdateLifespan() {
        lifespan += Time.deltaTime;
    }

    public override void Update()
    {
        if ((lifespan % 1.2) < 0.5 && ((lifespan + Time.deltaTime) % 1.2) > 0.5) {
            for (float i = 0f; i < 2.1; i++) {
                float enemyProjectileSpeed = 9f+2*i;
                playerPos = Player.Instance.transform.position;
                float ang = Mathf.Atan2((playerPos.y-transform.position.y),(playerPos.x-transform.position.x));
                direction = new Vector3(Mathf.Cos(ang+0.3f), Mathf.Sin(ang+0.3f), 0);
                var projectile = Instantiate(EnemyProjectile, transform.position+direction*0.4f, transform.rotation);
                projectile.Fire(enemyProjectileSpeed, direction);
                direction = new Vector3(Mathf.Cos(ang-0.3f), Mathf.Sin(ang-0.3f), 0);
                var projectile2 = Instantiate(EnemyProjectile, transform.position+direction*0.4f, transform.rotation);
                projectile2.Fire(enemyProjectileSpeed, direction);
            }
        }
        UpdateLifespan();
    }
}
