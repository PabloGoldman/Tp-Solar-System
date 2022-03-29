using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 6f;
    [SerializeField] Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (GameManager.self.GetPlayer() != null)
        {
            SetTarget();
        }

        Vector3 localOffset = target.transform.right * offset.x + target.transform.up * offset.y + target.transform.forward * offset.z;
        Vector3 desiredPosition = target.transform.position + localOffset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.fixedDeltaTime * smoothSpeed);

        transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, Time.fixedDeltaTime * smoothSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetTarget() => target = GameManager.self.GetPlayer().transform;
    
}
