using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    public float speed = 400f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
        turn();
    }

    void turn() {
        if (Input.GetKey(KeyCode.A)) {
            GetComponent<Rigidbody>().position += Vector3.left * Time.deltaTime * speed;
        } else if (Input.GetKey(KeyCode.D)) {
            GetComponent<Rigidbody>().position += Vector3.right * Time.deltaTime * speed;
        }
    }
}
