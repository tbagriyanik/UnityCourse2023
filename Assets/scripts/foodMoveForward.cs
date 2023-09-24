using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodMoveForward : MonoBehaviour
{
    public float speed = 40;
    public float topBound = 30;
    public float lowerBound = -10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.z > topBound)
            Destroy(gameObject);

        if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            Debug.Log("Kaçtı");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
