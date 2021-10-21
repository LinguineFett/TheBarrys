using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform playerTransform;
    public float sensitivityX = 150f;
    private float sensitivityY;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;
    float rotationX = 0f;

    void Start()
    {
        playerTransform = GameObject.Find("Player (Humanoid)").GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        sensitivityY = sensitivityX * 9 / 16 * 1.5f;
    }
    void Update()
    {
        Vector3 playerTransformCorrected = new Vector3(playerTransform.position.x, playerTransform.position.y + 1f, playerTransform.position.z);
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1f, playerTransform.position.z);
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        //float rotationY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime:
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
