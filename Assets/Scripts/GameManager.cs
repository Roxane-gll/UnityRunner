using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] float slowness = 10f;
    bool isGameEnded = false;

    [SerializeField] ObstacleSpawner obstacleSpawner;
    int timeToLevel = 100;
   int timeBetweenLevel = 100;

   public int bonus = 0;

   [SerializeField] int bonusMulti = 50;

    void Update() {
        if (isGameEnded == false) {
            float score = Time.timeSinceLevelLoad * 10f;
            scoreText.SetText(CalculScore(score));
            if (score > timeToLevel) {
                AddLevel();
            }
        }
    }

    public void EndGame() {
        if (isGameEnded == false) {
            isGameEnded = true;
            StartCoroutine(RestartLevel());
        }
    }
    
    IEnumerator RestartLevel() {
        Time.timeScale = 1f/slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        yield return new WaitForSeconds(1f/slowness);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddLevel() {
        if (obstacleSpawner.nbObstacle < 4) {
            obstacleSpawner.nbObstacle = obstacleSpawner.nbObstacle + 1;
        }
        timeToLevel = timeToLevel + timeBetweenLevel;
    }

    public string CalculScore(float timeScore) {
        float totalScore = timeScore + bonus * bonusMulti;
        return totalScore.ToString("0");
    }
}
