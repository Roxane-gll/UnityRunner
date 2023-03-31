using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float sidewaysForce = 500;

    void FixedUpdate()
    {
        if (Input.GetKey("d")) {
            rb.AddForce(new Vector3(sidewaysForce * Time.deltaTime, 0 ,0), ForceMode.VelocityChange);
        }
        if (Input.GetKey("q")) {
            rb.AddForce(new Vector3(-sidewaysForce * Time.deltaTime, 0 ,0), ForceMode.VelocityChange);
        }

        if (rb.position.y < -2f) {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
