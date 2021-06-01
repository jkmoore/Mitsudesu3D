using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy; //The game object to be spawned

    public int startingDist = 30; //Distance from the player when spawned

    public float timeBetweenWaves = 5f; //Time between waves being spawned
    private float countdown = 2f; //Time until next wave

    public int numEnemies = 3; //Number of enemies spawned per wave

    //Skins for enemies
    public Material Material1;
    public Material Material2;
    public Material Material3;
    public Material Material4;

    //If time for the next wave, spawn wave and reset countdown
    //Subtract from countdown
    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    //Spawn the number of enemies to be spawned per wave, increment this number
    void SpawnWave()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            SpawnEnemy();
        }
        numEnemies++;
    }

    //Spawn an enemy at a random position with a random skin
    //All enemies are startingDist away with y=0, rotated to face the player
    void SpawnEnemy()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        float z = Mathf.Sin(angle) * startingDist;
        float x = Mathf.Cos(angle) * startingDist;
        Vector3 position = new Vector3(x, 0, z);
        Quaternion rotation = Quaternion.Euler(0, -1 * angle * (180 / Mathf.PI), 0);
        GameObject newEnemy = Instantiate(enemy, position, rotation);
        int materialNo = Random.Range(0, 5);
        if (materialNo == 0) //keep original material, done spawning
            return;
        else if (materialNo == 1)
            newEnemy.GetComponent<MeshRenderer>().material = Material1;
        else if (materialNo == 2)
            newEnemy.GetComponent<MeshRenderer>().material = Material2;
        else if (materialNo == 3)
            newEnemy.GetComponent<MeshRenderer>().material = Material3;
        else
            newEnemy.GetComponent<MeshRenderer>().material = Material4;
    }
}
