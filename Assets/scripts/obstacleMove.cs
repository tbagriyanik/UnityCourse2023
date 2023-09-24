using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMove : MonoBehaviour
{
    public float speed = 15;

    private PlayerController3 playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController3>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver) return;

        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x < -10 && gameObject.CompareTag("obstacle"))
            Destroy(gameObject);
    }
}
