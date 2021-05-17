using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public CarTag carTag;

    public TMP_Text timeText;

    public GameObject endGamePanel;
    public TMP_Text runTimeText;
    public TMP_Text highScoreText;

    public float elapsedTime;
    public float startTime;

    public float delay = 4f;

    private string runTime;

    void Start()
    {
        startTime = Time.time + delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (carTag.hasCollided)
        {
            EndGame();
            return;
        }

        UpdateTime();
    }

    public void UpdateTime()
    {
        elapsedTime = Time.time - startTime;

        string minutes = ((int)elapsedTime / 60).ToString("00");
        string seconds = (elapsedTime % 60).ToString("00");
        runTime = minutes + ":" + seconds;
        timeText.text = "TIME\n" + runTime;

        if(elapsedTime > PlayerPrefs.GetFloat("HighScore", 0.0f))
        {
            PlayerPrefs.SetFloat("HighScore", elapsedTime);
        }
            
    }

    public void EndGame()
    {
        endGamePanel.SetActive(true);
        
        runTimeText.text = "RUN TIME\n" + runTime;

        string minutes = ((int)PlayerPrefs.GetFloat("HighScore") / 60).ToString("00");
        string seconds = (PlayerPrefs.GetFloat("HighScore") % 60).ToString("00");
        highScoreText.text = "BEST TIME\n" + minutes + ":" + seconds;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("APPLICATION QUIT");
        Application.Quit();
    }

}
