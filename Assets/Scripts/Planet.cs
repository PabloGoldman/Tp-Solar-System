using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] float speed, rotationSpeed;
    public Transform sun, self;

    // Start is called before the first frame update
    void Start()
    {
        SetDefaultValue();
    }

    // Update is called once per frame
    void Update()
    {
        RotateAround(sun, speed);
        RotateAround(self, rotationSpeed);
    }

    private void RotateAround(Transform target, float speed)
    {
        transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime);
    }

    private void SetDefaultValue()
    {
        if (speed == 0)
            speed = 5;
        else if (rotationSpeed == 0)
            rotationSpeed = 50;
    }
}
