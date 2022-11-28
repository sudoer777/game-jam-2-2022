using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovVShooter : Enemy
{
    private float lifespan = 0;
    Vector3 playerPos;
    Vector3 direction;
    public Projectile EnemyProjectile;
    private Vector3 projectileOffset;

    public void UpdateLifespan() {
        lifespan += Time.deltaTime;
        projectileOffset = new Vector3(0.0f, 2.4f, 0.0f);
    }

    public override void Update()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) >= 30f) {
            return;
        }
        if ((lifespan % 1.2) < 0.5 && ((lifespan + Time.deltaTime) % 1.2) > 0.5) {
            for (float i = 0f; i < 2.1; i++) {
                float enemyProjectileSpeed = 36f+8*i;
                playerPos = Player.Instance.transform.position;
                float ang = Mathf.Atan2((playerPos.y-transform.position.y-projectileOffset.y),(playerPos.x-transform.position.x));
                direction = new Vector3(Mathf.Cos(ang+0.3f), Mathf.Sin(ang+0.3f), 0);
                var projectile = Instantiate(EnemyProjectile, transform.position+direction*0.4f + projectileOffset, transform.rotation);
                projectile.Fire(enemyProjectileSpeed, direction);
                direction = new Vector3(Mathf.Cos(ang-0.3f), Mathf.Sin(ang-0.3f), 0);
                var projectile2 = Instantiate(EnemyProjectile, transform.position+direction*0.4f + projectileOffset, transform.rotation);
                projectile2.Fire(enemyProjectileSpeed, direction);
            }
        }
        UpdateLifespan();
        base.Update();
    }
}
