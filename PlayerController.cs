using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private Rigidbody characterBody;

    public float playerSpeed = 8.0f;
    public float jumpSpeed = 100f;
    public float rotateSpeed = 100f;
    public Camera followCamera;
    

    private Rigidbody m_Rb;
    private Vector3 m_CameraPos;

    // Start is called before the first frame update
    void Awake()
    {
        //Camera stuff
        m_Rb = GetComponent<Rigidbody>();
        m_CameraPos = followCamera.transform.position - transform.position;
    }

   // public static PlayerController GetInstance()
    //{
   //     return instance;
   //}

    void FixedUpdate()
    {
        if (playerTurn.IsPlayerTurn())
        {
            //Movement stuff
            transform.Translate(Vector3.forward * playerSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

            transform.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))

            {

                Jump();

            }
        }

    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //characterBody.velocity = Vector3.up * 10f; 
            characterBody.AddForce(Vector3.up * jumpSpeed);
        }
    
    }

}