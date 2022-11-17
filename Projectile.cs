using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    [SerializeField] private GameObject damageIndicatorPrefab;
    //[SerializeField] private float weaponDamage;

    private bool isActive;

  
    public void Initialize(Vector3 direction)
    {
        isActive = true;

    }



    void Update()
    {
        if (isActive)
        {
            //shooting direction and selfdestruct
            projectileBody.MovePosition(transform.position + transform.forward);
            Destroy(this.gameObject, 3);
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
       //Why does a damageIndicator end up in the middle om the arena?
        GameObject damageIndicator = Instantiate(damageIndicatorPrefab);
        damageIndicator.transform.position = collision.GetContact(0).point;
        
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


        
        Destroy(this.gameObject);
        
        
    }
   

}
