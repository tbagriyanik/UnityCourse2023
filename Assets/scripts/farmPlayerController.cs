using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class farmPlayerController : MonoBehaviour
{
    float xRange = 20;
    float horizontalInput;
    float speed = 20.0f;

    public GameObject projectilePrefab;

    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerAnim.SetFloat("Speed_f",0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.localPosition, projectilePrefab.transform.rotation);
        }
    }
}
