using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    public UnityEditor.Animations.AnimatorController animatorController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player.Instance.GetComponent<Animator>().runtimeAnimatorController = animatorController;
            Destroy(this.gameObject);
        }

    }
}