using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private Rigidbody characterBody;
    [SerializeField] private float speed;
    private float mouseX;
    public float sensitivity = 2.0f;


    private void Start()
    {

    }

    void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {

            {
                Move();
                Rotate();
            }
            void Move()
            {
                Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                transform.position += movement * speed * Time.deltaTime;

            }

            void Rotate()
            {
                mouseX += Input.GetAxis("Mouse X") * sensitivity;
                transform.eulerAngles = new Vector3(0, mouseX, 0);
            }



            /*
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 MovementDirection = new Vector3(horizontalInput, 0, verticalInput);
            MovementDirection.Normalize();

            transform.Translate(MovementDirection * speed * Time.deltaTime, Space.World);

            if (MovementDirection != Vector3.zero) 
            {
                Quaternion toRotation = Quaternion.LookRotation(MovementDirection, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * speed * Time.deltaTime);
            }
            */
            if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor())

            {

                Jump();

            }



        }

    }





    void Jump()

    {

        //characterBody.velocity = Vector3.up * 10f; 

        characterBody.AddForce(Vector3.up * 2000f);

    }





    private bool IsTouchingFloor()

    {

        RaycastHit hit;

        // Parameters: 

        // - The center from where we shoot 

        // - Radius of the sphere 

        // - Direction of the sphere 

        // - hit parameter 

        // - Distance the sphere 

        bool result = Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);

        return result;

    }
}