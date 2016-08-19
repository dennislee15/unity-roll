using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public float spawnTime = 3f;
    public GameObject ball;
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    int totalBalls;
    int maxBalls = 1;

	void Start () {
        totalBalls = 0;
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Spawn () {
        if (totalBalls >= maxBalls)
        {
            return;
        }
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(ball, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        totalBalls++;
	}
}
