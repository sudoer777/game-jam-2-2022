using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            // do damage here, for example:
            collision.gameObject.GetComponent<Player>().Heal();
            Destroy(this.gameObject);
        }
    }
}
