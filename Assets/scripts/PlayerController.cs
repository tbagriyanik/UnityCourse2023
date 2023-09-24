using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 20.0f;
    float turnSpeed = 45;
    float horizontalInput;
    float forwardInput;

    public Camera main;
    public Camera onden;


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.C))
        {
            main.enabled = !main.enabled;
            onden.enabled = !onden.enabled;
        }

    }
}
