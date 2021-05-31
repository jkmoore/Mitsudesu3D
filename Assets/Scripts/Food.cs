using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject gameMaster;

    void Start()
    {
        gameMaster = GameObject.Find("GameMaster");
    }

    void OnMouseDown()
    {
        if (gameMaster.GetComponent<GameOver>().GameIsOver()) return;
        if (this.gameObject.name == "Fish(Clone)")
            gameMaster.GetComponent<GameOver>().GainFish();
        else if (this.gameObject.name == "Wagyu(Clone)")
            gameMaster.GetComponent<GameOver>().GainWagyu();
        else
            gameMaster.GetComponent<GameOver>().GainLife();
        Destroy(this.gameObject);
    }
}
