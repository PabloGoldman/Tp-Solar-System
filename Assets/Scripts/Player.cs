using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    //[SerializeField] Vector3 upSpeed;
    [SerializeField] float speedX, speedY;
    [SerializeField] Vector3 rotationSpeed;

    [SerializeField] float maxVelocityY = 25;

    Rigidbody rb;

    void Start()
    {
        rb = new Rigidbody();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-rotationSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(speedX, 0, 0));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.y < maxVelocityY)
            {
                rb.AddForce(new Vector3(0, speedY, 0));
            }
        }

        //Vector3 movement = new Vector3(speedX, 0.0f, speedY);
        //rb.AddForce(movement);
    }
}
