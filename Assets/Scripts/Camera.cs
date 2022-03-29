using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Transform target;
    public float smoothSpeed = 6f;
    [SerializeField] Vector3 offset;

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

    public void SetTarget() => target = GameManager.self.GetPlayer().transform;
    
}
