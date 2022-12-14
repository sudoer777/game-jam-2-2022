using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] public float hp;

    protected Rigidbody2D rb;
    public GameObject heart;
    public GameObject winScreen;

    public virtual void Awake()
    {   
        heart = (GameObject) Resources.Load("HealthPickup");//heart = LoadPrefabFromFile("HealthPickup");
        rb = GetComponent<Rigidbody2D>();
    }
    public virtual void Update (){

    }
    public virtual void OnHit(float damage) {
        hp -= damage;
        if (hp <= 0) {
            if (Random.Range(0, 1) < 0.1f) { 
                heart = Instantiate(heart, transform.position, Quaternion.identity);
            }

            if (this.gameObject.name == "Boss")
            {
                Pause.PauseGame(winScreen);
            }
            Destroy(this.gameObject);   
        }
    }

}
