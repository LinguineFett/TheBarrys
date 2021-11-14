using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Enemy" && PlayerMovement.isAttacking == true) {
            Debug.Log("Hit");
        }
    }

    private void OnCollisionExit(Collision other) {
        PlayerMovement.isAttacking = false;
    }

}
