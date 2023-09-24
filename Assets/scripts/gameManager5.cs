using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager5 : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public GameObject newGamePanel;

    private float spawnRate = 3;

    private int score = 0;

    public bool isGameActive = true;

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        isGameActive = true;
        newGamePanel.SetActive(false);        
    }
    void Start()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = "" + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
