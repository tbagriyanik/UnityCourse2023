using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpeed : MonoBehaviour
{
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerAnim.SetFloat("Speed_f", 0);
    }

}
