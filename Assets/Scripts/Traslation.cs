using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traslation : MonoBehaviour
{
    [SerializeField] float speed;

    public Transform sun;

    // Start is called before the first frame update
    void Start()
    {
        SetDefaultValue();
    }

    // Update is called once per frame
    void Update()
    {
        RotateAround(sun, speed);
    }

    private void RotateAround(Transform target, float speed)
    {
        transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime);
    }

    private void SetDefaultValue()
    {
        if (speed == 0)
            speed = 5;
    }
}
