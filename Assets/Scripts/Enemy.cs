using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;

    public GameObject gameMaster;

    void Awake()
    {
        GameObject camera = GameObject.Find("Main Camera");
        target = camera.transform;
        gameMaster = GameObject.Find("GameMaster");
    }

    void OnMouseDown()
    {
        if (transform.position.y == 0 && !gameMaster.GetComponent<GameOver>().GameIsOver())
        {
            Destroy(this.gameObject);
            gameMaster.GetComponent<GameOver>().ScoreUp();
        }
    }

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
