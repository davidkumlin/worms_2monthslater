using UnityEngine;
using System.Collections;

public class SpiderWeb : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "P1")
        {



            collision.gameObject.GetComponent<Stats>().TakeDamage(2);
            Debug.Log("Projectile - Damage to player1");


        }
        else if (collision.gameObject.tag == "P2")
        {



            collision.gameObject.GetComponent<Stats>().TakeDamage(2);
            Debug.Log("Projectile - Damage to player2");


        }

    }
}
