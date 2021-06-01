using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //Game score (number of enemies destroyed), lives remaining, fish/wagyu obtained
    private int score = 0;
    public int lives = 5;
    private int fish = 0;
    private int wagyu = 0;

    //Display game score, game over message, lives remaining, fish/wagyu counts
    public Text scoreText, gameOverText, lifeText, fishText, wagyuText;

    private bool gameIsOver = false; //Determines game over status

    public Text restartText;  //Label for restart button
    public Button restartButton; //Button to restart the game after it ends


    //Return game status (used by enemy/item classes)
    public bool GameIsOver()
    {
        return gameIsOver;
    }


    //Increase score, play appropriate sound effect
    //"Mitsudesu" changes to "Sugoiyo" every tenth point
    public void ScoreUp()
    {
        score++;

        if (score >= 10 && score % 10 == 0)
            SoundManagerScript.PlaySound("Sugoiyo");
        else
            SoundManagerScript.PlaySound("Mitsudesu");
    }


    //Decrease lives, play appropriate sound effect, end game at zero lives
    //"Damedesuyo" changes to "Kiken" when reduced to one life
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


    //Increase lives, play sound effect
    public void GainLife()
    {
        lives++;
        SoundManagerScript.PlaySound("Arigatogozaimasu");
    }


    //Increase fish, update text, play sound effect
    public void GainFish()
    {
        fish++;
        fishText.text = fish.ToString();
        SoundManagerScript.PlaySound("Supidokan");
    }


    //Increase wagyu, update text, play sound effect
    public void GainWagyu()
    {
        wagyu++;
        wagyuText.text = wagyu.ToString();
        SoundManagerScript.PlaySound("Shokuryohin");
    }


    //End the game: play game over sound, show game over text, freeze time,
    //update game over status, show and set restart button
    public void EndGame()
    {
        SoundManagerScript.PlaySound("Kinkyujitaisengen");
        gameOverText.text = "Game Over";
        Time.timeScale = 0;
        gameIsOver = true;
        restartButton.gameObject.SetActive(true);
        restartText.text = "Restart";
    }


    //Restart the game: unfreeze time, reload the scene
    public void Restart()
    {
        if (gameIsOver)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    //Turn off the restart button, set the score and life text to the default
    void Start()
    {
        restartButton.gameObject.SetActive(false);
        scoreText.text = score.ToString();
        lifeText.text = lives.ToString();

    }


    //Put these lines in scoreup and gainlife/loselife?
    void Update()
    {
        scoreText.text = score.ToString();
        lifeText.text = lives.ToString();
    }
}
