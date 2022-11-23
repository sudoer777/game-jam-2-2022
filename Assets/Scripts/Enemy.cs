using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float lifespan = 0;
    public Rigidbody2D rb;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    /*public void Awake() 
    {
    }

    // Update is called once per frame
    public void Update() {

    }*/

}
