using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public GameObject pixelTextObject;
    private TextMesh textMesh;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        textMesh = pixelTextObject.GetComponent<TextMesh>();
        textMesh.text = score.ToString();
    }

    public void IncreaseScore(int addedPoints)
    {
        score = score + addedPoints;
        textMesh.text = score.ToString();
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
