using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject gameMaster; //Game master to track scores/lives/game status

    //Set the game master
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster");
    }

    //Identify the type of item (Fish, Wagyu, Mask) tapped, update scores/lives
    //in the game master accordingly, destroy the item
    void OnMouseDown()
    {
        //Do not update scores or destroy if the game is over
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
