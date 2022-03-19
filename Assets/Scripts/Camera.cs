using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;
    [SerializeField] GameObject targetToFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = targetToFollow.transform.position + offset;
        //transform.rotation = targetToFollow.transform.rotation;

        //transform.LookAt(targetToFollow.transform);
    }
}
