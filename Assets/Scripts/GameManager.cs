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

    void Update() {
        if (isGameEnded == false) {
             float score = Time.timeSinceLevelLoad * 10f;
            scoreText.SetText(score.ToString("0"));
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
}
