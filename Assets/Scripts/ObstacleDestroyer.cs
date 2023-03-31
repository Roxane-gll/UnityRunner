using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{

    void OnCollisionExit(Collision collisionInfo) {
        if (collisionInfo.collider.tag == "Ground") {
           Destroy(gameObject);
        }
    }
}
