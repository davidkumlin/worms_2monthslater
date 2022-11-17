using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    float degreesPerSecond = 40;

    //[SerializeField] private PlayerTurn playerTurn;
    [SerializeField] GameObject pickupHealth;
    [SerializeField] GameObject pickupMana;


    private void Awake()
    {

    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider collider)

    {

        
        if (collider.gameObject.tag == "P1" || collider.gameObject.tag == "P2")
        {
            if (GameObject.FindWithTag("Hearth"))
            {
                collider.GetComponent<Stats>().TakeDamage(-5);
                Debug.Log("Player Picked Health up");

            }

            else if (GameObject.FindWithTag("Potion_Mana"))
            {
                collider.GetComponent<Stats>().SpellCast(-8);
                Debug.Log("Player Picked Mana up");
            }



            Destroy(this.gameObject);
            Debug.Log("pickupscript");
        }


        
    }
}