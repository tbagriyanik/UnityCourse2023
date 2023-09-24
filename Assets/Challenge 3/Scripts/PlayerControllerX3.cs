﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerX3 : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 3f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !gameOver && transform.position.y < 20)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (gameOver) return;

        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }
        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("ground"))
        {
            playerRb.AddForce(Vector3.up * 20, ForceMode.Impulse);
        }
    }
}