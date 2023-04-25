using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusColider : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo) {
        if (collisionInfo.collider.tag == "Player") {
            FindObjectOfType<GameManager>().bonus = FindObjectOfType<GameManager>().bonus + 1;
            Destroy(gameObject);
        }
    }
}
