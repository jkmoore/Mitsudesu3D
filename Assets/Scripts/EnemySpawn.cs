using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;

    public int startingDist = 30;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public int numEnemies = 3;

    public Material Material1;
    public Material Material2;
    public Material Material3;
    public Material Material4;

    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    void SpawnWave()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            SpawnEnemy();
        }
        numEnemies++;
    }

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
