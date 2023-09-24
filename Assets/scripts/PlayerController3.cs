using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    Rigidbody rbPlayer;

    public float gravityMod = 2;
    public float jumpForce = 400;
    public bool isOnGround = true;

    public bool gameOver;

    private Animator playerAnim;

    public ParticleSystem explosionParticle;

    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityMod;

        playerAnim.SetFloat("Speed_f", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) return;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (other.gameObject.CompareTag("obstacle"))
        {
            gameOver = true;
            dirtParticle.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1.0f);
            if (explosionParticle)
                explosionParticle.Play();
        }
    }
}
