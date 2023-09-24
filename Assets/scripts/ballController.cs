using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerUpObject;

    public bool hasPowerup;
    public float powerUpStrength = 25;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("pivot");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
        powerUpObject.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerUpObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") && hasPowerup)
        {
            Rigidbody enemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFrom = (collision.gameObject.transform.position - transform.position);
            enemy.AddForce(awayFrom * powerUpStrength, ForceMode.Impulse);
            //Destroy(collision.gameObject);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerUpObject.SetActive(false);
    }
}
