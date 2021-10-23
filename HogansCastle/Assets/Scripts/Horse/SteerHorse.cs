using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerHorse : MonoBehaviour
{
    public float turnAmount = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            transform.localEulerAngles = new Vector3(0, -turnAmount, 0);
        } else if (Input.GetKey(KeyCode.D)) {
            transform.localEulerAngles = new Vector3(0, turnAmount, 0);
        } else {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
