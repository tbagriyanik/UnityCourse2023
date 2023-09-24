using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    public GameObject spanwObject;
    private PlayerController3 playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController3>();

        InvokeRepeating("spawn", 2, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawn()
    {
        if (playerControllerScript.gameOver) return;
        Instantiate(spanwObject, transform.position, spanwObject.transform.rotation);
    }
}
