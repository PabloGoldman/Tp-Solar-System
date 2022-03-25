using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCamera : MonoBehaviour
{
    public Transform target;

    [SerializeField]float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.right * Time.deltaTime * rotationSpeed);
    }
}
