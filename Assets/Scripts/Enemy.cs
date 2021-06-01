using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;      //Enemy movement speed
    private Transform target;     //The location the enemy moves toward
    public GameObject gameMaster; //Game master to track scores/lives/game status


    //Set target and game master on awake
    void Awake()
    {
        GameObject camera = GameObject.Find("Main Camera");
        target = camera.transform;
        gameMaster = GameObject.Find("GameMaster");
    }


    //If the game is not over and the enemy is in the enemy zone (y=0 plane),
    //destroy and increase score on tap
    void OnMouseDown()
    {
        if (transform.position.y == 0 && !gameMaster.GetComponent<GameOver>().GameIsOver())
        {
            Destroy(this.gameObject);
            gameMaster.GetComponent<GameOver>().ScoreUp();
        }
    }


    //If within 2 units of the player, self-destruct and subtract a life
    //Otherwise advance the enemy toward the player
    void Update()
    {
        if (!(transform.position.x > 2) && !(transform.position.x < -2) &&
            !(transform.position.z > 2) && !(transform.position.z < -2))
        {
            Destroy(this.gameObject);
            gameMaster.GetComponent<GameOver>().LoseLife();
        }
        if (transform.position.y == 0)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
