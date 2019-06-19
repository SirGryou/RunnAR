using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{ 
 [Space(10)]
    [Header("Obstacles:")]
    public float objectSpawnWait;
public Vector3 randPos1;
public Vector3 randPos2;
public Vector3 randPos3;
public float spawnZ; //distance between player and the object 
public float spawnDistance; //distance between object  
public GameObject[] obstacles;

private Transform playerTranform;

void Start()
{
    playerTranform = GameObject.FindGameObjectWithTag("Player").transform;

}

void Update()
{
    if (playerTranform.position.z > spawnZ * spawnDistance)
    {
        StartCoroutine(SpawnObstacle());
    }
}

IEnumerator SpawnObstacle()
{
    if (obstacles.Length > 0)
    {
        int randomObstacle = Random.Range(0, obstacles.Length);

        GameObject obstacle = Instantiate(obstacles[randomObstacle]);
        obstacle.transform.SetParent(transform);
        MoveObjectsToTheFront(obstacle);
    }

    yield return new WaitForSeconds(5);
}

private void MoveObjectsToTheFront(GameObject moveObject)
{
    int randomPosNum = Random.Range(0, 2);
    Vector3 randomPosition;

    if (randomPosNum == 0)
        randomPosition = randPos1; // Vector3(2, 0.5, 5)
    else if (randomPosNum == 1)
        randomPosition = randPos2; // Vector3(0, 0.5, 5)
    else
        randomPosition = randPos3; // Vector3(-2, 0.5, 5)

    moveObject.transform.position = randomPosition * spawnZ;
    spawnZ += spawnDistance;
}
}