using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject mask;
    public GameObject fish;
    public GameObject wagyu;

    //Height range for items, adjusted for visibility and to avoid overlap with enemies
    //Includes yMin and yMax flipped over y-axis
    public float yMax = 8f;
    public float yMin = 4f;

    public int dist = 10; //Item distance from player

    public float timeBetweenDrops = 5f; //Time between item spawns
    public float countdown = 5f;        //Time before next item spawn

    //If time for next spawn, spawn item and reset countdown
    //Subtract from countdown
    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnItem();
            countdown = timeBetweenDrops;
        }

        countdown -= Time.deltaTime;
    }

    //Spawn a random item at a random position
    //All items are dist away and in the preset height range, rotated to face the player
    void SpawnItem()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        float z = Mathf.Sin(angle) * 10; //change 10 to dist?
        float x = Mathf.Cos(angle) * 10; //change 10 to dist?
        float y = Random.Range(yMin, yMax);
        int yPositive = Random.Range(0, 2); //randomly make pos or neg
        if (yPositive == 0) y *= -1;
        Vector3 position = new Vector3(x, y, z);
        Quaternion rotation;
        int itemNo = Random.Range(0, 3);
        //Each image must be rotated differently to face the player
        if (itemNo == 0)
        {
            rotation = Quaternion.Euler(0, -1 * angle * (180 / Mathf.PI), 0);
            Instantiate(mask, position, rotation);
        }
        else if (itemNo == 1)
        {
            rotation = Quaternion.Euler(0, -1 * angle * (180 / Mathf.PI) - 270, 0);
            Instantiate(fish, position, rotation);
        }
        else
        {
            rotation = Quaternion.Euler(0, -1 * angle * (180 / Mathf.PI) - 90, 0);
            Instantiate(wagyu, position, rotation);
        }
    }
}
