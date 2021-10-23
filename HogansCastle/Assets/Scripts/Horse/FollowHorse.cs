using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHorse : MonoBehaviour
{
    public GameObject horse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float newXPos = (horse.transform.position.x);
        float newYPos = (horse.transform.position.y + 5);
        float newZPos = (horse.transform.position.z - 10);
        transform.position = new Vector3(newXPos, newYPos, newZPos);
    }
}
