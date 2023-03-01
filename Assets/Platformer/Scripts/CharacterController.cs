using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float acceleration = 10f;
    public float jumpforce = 10f;
    public float maxSpeed = 3f;
    public float jumpboast = 5f;
    public bool isGrounded;
    public float turbo = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.velocity += horizontalAxis * Vector3.right * Time.deltaTime * acceleration;

        Collider col = GetComponent<Collider>();
        float halfheight = col.bounds.extents.y + 0.03f;

        isGrounded =  Physics.Raycast(transform.position, Vector3.down, 2f);

        rbody.velocity = new Vector3(Mathf.Clamp(rbody.velocity.x, -maxSpeed, maxSpeed), rbody.velocity.y,rbody.velocity.z);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rbody.AddForce(Vector3.up*jumpforce,ForceMode.Impulse);
            }

            Color lineColor = (isGrounded) ? Color.green : Color.red;
            Debug.DrawLine(transform.position,transform.position + Vector3.down *halfheight, lineColor,0f,false);

            rbody.velocity = Vector3.ClampMagnitude(rbody.velocity, maxSpeed);
            if (Input.GetKey(KeyCode.Space))
            {
                rbody.AddForce(Vector3.up * jumpboast, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rbody.AddForce(Vector3.right * turbo, ForceMode.Force);
            }

            float xVelocity = Mathf.Clamp(rbody.velocity.x, -maxSpeed, maxSpeed);
            if( Mathf.Abs(horizontalAxis) < 0.1f)
            {
                xVelocity += 0.9f;
            }

           
            float speed = rbody.velocity.magnitude;
            GetComponent<Animator>().SetFloat("Speed", speed);

            Animator animator = GetComponent<Animator>();
            animator.SetBool("Grounded",!isGrounded);

    }
}
