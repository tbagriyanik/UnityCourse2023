using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targets : MonoBehaviour
{
    private Rigidbody targetRb;
    private gameManager5 gameManager;
    public ParticleSystem explosionParticle;

    public int pointValue = 5;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -3;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(randomForce(), ForceMode.Impulse);
        targetRb.AddTorque(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse);

        transform.position = randomPos();
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager5>();
    }

    private Vector3 randomPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private float randomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 randomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if (!gameManager.isGameActive) return;

        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }

        Destroy(gameObject);
    }
}
