using UnityEngine;

public class Item : MonoBehaviour
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
        if (gameMaster.GetComponent<GameMaster>().GameIsOver())
            return;

        if (this.gameObject.name == "Fish(Clone)")
            gameMaster.GetComponent<GameMaster>().GainFish();
        else if (this.gameObject.name == "Wagyu(Clone)")
            gameMaster.GetComponent<GameMaster>().GainWagyu();
        else
            gameMaster.GetComponent<GameMaster>().GainLife();

        Destroy(this.gameObject);
    }
}
