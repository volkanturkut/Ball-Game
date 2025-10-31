using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject loseUI;
    public GameObject WinUI;

    public int score;

    public Text loseScoreText,winScoreText;
    public Text inGameScoreText;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void LevelEnd()
    {
        loseUI.SetActive(true);
        loseScoreText.text = " Toplam Puan; " + score;
        inGameScoreText.gameObject.SetActive(false);

    }

    public void WinLevel()
    {
        WinUI.SetActive(true);
        winScoreText.text = " Toplam Puan; " + score;
        inGameScoreText.gameObject.SetActive(false);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AddScore(int pointValue)
    {
        score += pointValue;
        inGameScoreText.text = "Puan: " + score;
    }

    public void StartApp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AppQuit()
    {
        Application.Quit();
    }
}
