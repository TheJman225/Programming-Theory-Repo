using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float spawnRate { get; }  = 1;
    private float spawnRange { get;  } = 4;
    private float spawnDistance { get; } = 150;
    [SerializeField] List<GameObject> spawnableObjects;
    private GameObject objectToSpawn;
    private Vector3 spawnLocation;

    private int m_score;
    public int score { get { return m_score; } // ENCAPSULATION
        set
        {
            if (value < 0)
            {
                Debug.LogError("Score cannot be negative.");
            }
        else
            {
                m_score = value;
            }
        }
    }
    [SerializeField] TextMeshProUGUI scoreText;

    bool gameOver;
    [SerializeField] GameObject gameOverScreen;

    void Start()
    {
        scoreText.text = ("Score: 0");
        StartCoroutine("SpawnObjectTimer");
    }

    void Update()
    {
        if (Input.anyKey && gameOver)
        {
            RestartGame();
        }
    }

    void SpawnObject()
    {
        objectToSpawn = spawnableObjects[Random.Range(0, spawnableObjects.Count)];
        spawnLocation = new Vector3(Random.Range(-spawnRange, spawnRange), 0, spawnDistance);
        Instantiate(objectToSpawn, spawnLocation, objectToSpawn.transform.rotation);
    }

    IEnumerator SpawnObjectTimer()
    {
        SpawnObject();
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine("SpawnObjectTimer");
    }

    public void AddScore(int coinValue)
    {
        score += coinValue;
        scoreText.text = ("Score: " + score);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver = true;
        gameOverScreen.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
