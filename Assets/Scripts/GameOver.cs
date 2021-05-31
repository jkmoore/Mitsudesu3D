using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private int score = 0;
    public int lives = 5;
    private int fish = 0;
    private int wagyu = 0;
    public Text scoreText;
    public Text gameOverText;
    public Text lifeText;
    public Text fishText;
    public Text wagyuText;
    private bool gameIsOver = false;
    public Text restartText;
    public Button restartButton;

    public bool GameIsOver()
    {
        return gameIsOver;
    }

    public void ScoreUp()
    {
        score++;
        if (score >= 10 && score % 10 == 0)
            SoundManagerScript.PlaySound("Sugoiyo");
        else
            SoundManagerScript.PlaySound("Mitsudesu");
    }

    public void LoseLife()
    {
        if (lives > 0)
            lives--;
        if (lives > 1)
            SoundManagerScript.PlaySound("Damedesuyo");
        else if (lives == 1)
            SoundManagerScript.PlaySound("Kiken");
        else
            EndGame();
    }

    public void GainLife()
    {
        lives++;
        SoundManagerScript.PlaySound("Arigatogozaimasu");
    }

    public void GainFish()
    {
        fish++;
        fishText.text = fish.ToString() ;
        SoundManagerScript.PlaySound("Supidokan");
    }

    public void GainWagyu()
    {
        wagyu++;
        wagyuText.text = wagyu.ToString();
        SoundManagerScript.PlaySound("Shokuryohin");
    }

    public void EndGame()
    {
        SoundManagerScript.PlaySound("Kinkyujitaisengen");
        gameOverText.text = "Game Over";
        Time.timeScale = 0;
        gameIsOver = true;
        restartButton.gameObject.SetActive(true);
        restartText.text = "Restart";
    }

    public void Restart()
    {
        if (gameIsOver)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        restartButton.gameObject.SetActive(false);
        scoreText.text = score.ToString();
        lifeText.text = lives.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        lifeText.text = lives.ToString();
    }
}
