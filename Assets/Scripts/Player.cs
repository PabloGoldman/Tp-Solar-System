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

    private Vector3 initialPos;
    private Quaternion initialRot;

    Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        initialPos = transform.position;
        initialRot = transform.rotation;
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
            transform.Rotate(-transform.right);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Rotate(transform.right);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(-transform.up);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(transform.up);

        if (Input.GetKey(KeyCode.W))
            rb.AddForce(transform.forward * speedX);

        if (Input.GetKey(KeyCode.S))
            rb.AddForce(transform.forward * -speedX);

        if (Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.y < maxVelocityY)
                rb.AddForce(new Vector3(0, speedY, 0));
        }
    }

    public void ResetPlayerPos()
    {
        transform.position = initialPos;
        transform.rotation = initialRot;
        rb.velocity = Vector3.zero;
    }
}
