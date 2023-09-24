using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBalls : MonoBehaviour
{
    Rigidbody enemyRb;
    GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        if(transform.position.y < -10) {
            Destroy(gameObject);
        }
    }
}
