using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSShooter : Enemy
{
    private float lifespan = 0;
    Vector3 playerPos;
    Vector3 direction;
    public Projectile EnemyProjectile;
    private Vector3 projectileOffset;

    public void UpdateLifespan() {
        lifespan += Time.deltaTime;
        projectileOffset = new Vector3(0.0f, 4f, 0.0f);
    }

    public override void Update()
    {
        if ((lifespan % 2.5) < 1.2 && ((lifespan + Time.deltaTime) % 2.5) > 1.2) {
            for (int i = 0; i < 10; i++) {
                float enemyProjectileSpeed = 32f+Random.Range(0f, 20f);
                playerPos = Player.Instance.transform.position;
                float ang = Mathf.Atan2((playerPos.y-transform.position.y-projectileOffset.y),(playerPos.x-transform.position.x));
                float deviation = Random.Range(-1.5f, 1.5f);
                direction = new Vector3(Mathf.Cos(ang+deviation), Mathf.Sin(ang+deviation), 0);
                var projectile = Instantiate(EnemyProjectile, transform.position+direction*0.4f + projectileOffset, transform.rotation);
                projectile.Fire(enemyProjectileSpeed, direction);
            }   
        }
        UpdateLifespan();
    }
}
