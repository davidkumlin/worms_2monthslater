using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterWeapon : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;
    [SerializeField] private float projectileSpeed;

    //[SerializeField] private int manaCost;


    void Update()
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        if (Input.GetKeyDown(KeyCode.V) && gameObject.GetComponent<Stats>().hasMana == true)
        {
            if (Instantiate(projectilePrefab))
            {
                if (playerTurn.IsPlayerTurn())
                {
                    gameObject.GetComponent<Stats>().SpellCast(2);
                    Debug.Log("characterweapon - Spell has been casted");
                }

            }



            if (IsPlayerTurn)
            {


                GameObject newProjectile = Instantiate(projectilePrefab);
                newProjectile.transform.position = shootingStartPosition.position;
                newProjectile.transform.rotation = shootingStartPosition.rotation;
                newProjectile.GetComponent<Projectile>().Initialize(Vector3.forward * projectileSpeed * Time.deltaTime);


            }

        }
    }

}