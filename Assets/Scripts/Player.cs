using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    //[SerializeField] Vector3 upSpeed;
    [SerializeField] float speedX, speedY;
    [SerializeField] float rotationSpeed;

    [SerializeField] float maxVelocityY = 25;

    Rigidbody rb;

    void Start()
    {
        rb = new Rigidbody();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {

    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(-transform.right);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(transform.right);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-transform.up);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(transform.up);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speedX);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * -speedX);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.y < maxVelocityY)
            {
                rb.AddForce(new Vector3(0, speedY, 0));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Planet") //Preguntar como hacer para que solo con el tag del "padre" se pueda chequear
        //{
        //    rb.constraints = RigidbodyConstraints.FreezeRotation;
        //}
        //else
        //{
        //    rb.constraints = RigidbodyConstraints.None;
        //    rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        //}
    }
}
