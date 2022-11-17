using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {



        if (collision.gameObject.tag == "Projectile")
        {

            Destroy(this.gameObject);
            Debug.Log("Wall has been destroyed");

        }
    }
}
