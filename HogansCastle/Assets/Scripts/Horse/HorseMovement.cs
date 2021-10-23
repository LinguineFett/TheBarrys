using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    public float speed = 400f;
    public float turnSpeed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
        Turn();
    }

    void Turn() {
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * Time.deltaTime * turnSpeed;
        } else if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * Time.deltaTime * turnSpeed;
        }
    }
}
