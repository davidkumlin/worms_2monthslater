using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{

    [SerializeField] public float maxHealth;
    [SerializeField] private Image healthBar;
    [SerializeField] public bool isDead;


    [SerializeField] public float maxMana;
    [SerializeField] private Image manaBar;
    [SerializeField] public bool hasMana;



    [SerializeField] public static float currentHealth;
    [SerializeField] public static float currentMana;


    private Vector3 initialPosition;
    private Vector3 initialRotation;


    //Singleton stuff...
    private static Stats instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public static Stats GetInstance()
    {
        return instance;
    }

    public void ModifyCurrentHealth(float value)
    {
        currentHealth += value;
    }
    public void ModifyCurrentMana(float value)
    {
        currentMana += value;
    }

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        hasMana = true;
        //Start Stats and bar activation
        currentHealth = maxHealth;
        healthBar.fillAmount = 1f;
        currentMana = maxMana;
        manaBar.fillAmount = 1f;

        initialPosition = transform.position;
        initialRotation = transform.eulerAngles;
    }


    public void SpellCast(float magic)
    {

        {
            currentMana -= magic;
            manaBar.fillAmount = currentMana / maxMana;
            if (currentMana <= 1)
            {
                hasMana = false;
            }
        }

    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;

        Debug.Log("Stats - Damage to player");

        if (currentHealth <= 0)
        {
            isDead = true;
            Debug.Log("Player is Dead");
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            initialPosition = transform.position;
            initialRotation = transform.eulerAngles;
        }
    }

}
