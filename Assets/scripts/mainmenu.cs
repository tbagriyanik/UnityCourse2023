using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    private void Awake()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
    public void haritaYukle(int id)
    {
        SceneManager.LoadScene(id, LoadSceneMode.Single);
    }
}
