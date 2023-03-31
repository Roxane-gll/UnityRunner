using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float forwardForce = 1000f;

    void FixedUpdate()
    {
        rb.AddForce(Vector3.back * forwardForce * Time.deltaTime);
    }
}
