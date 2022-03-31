using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float forwardSpeed = 25f, horizontalSpeed = 7.5f, verticalSpeed = 5f;
    [SerializeField] float activeForwardSpeed, activeHorizontalSpeed, activeVerticalSpeed;

    [SerializeField] float forwardAcceleration = 2.5f, horizontalAcceleration = 2, upAcceleration = 2;

    [SerializeField] float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    [SerializeField] float rollSpeed = 90, rollAcceleration = 3.5f;

    private Vector3 initialPos;
    private Quaternion initialRot;

    Rigidbody rb;

    // Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        initialPos = transform.position;
        initialRot = transform.rotation;

        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Si estas en el juego

        if (ScManager.self.ActualScene() == "SampleScene")
        {
            Movement();
        }
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeHorizontalSpeed = Mathf.Lerp(activeHorizontalSpeed, Input.GetAxisRaw("Horizontal") * horizontalSpeed, horizontalAcceleration * Time.deltaTime);
        activeVerticalSpeed = Mathf.Lerp(activeVerticalSpeed, Input.GetAxisRaw("Up") * verticalSpeed, upAcceleration * Time.deltaTime);
    }

    private void Movement()
    {
        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeHorizontalSpeed * Time.deltaTime) +
            (transform.up * activeVerticalSpeed * Time.deltaTime);

    }

    public void ResetPlayerPos()
    {
        transform.position = initialPos;
        transform.rotation = initialRot;
    }
}
