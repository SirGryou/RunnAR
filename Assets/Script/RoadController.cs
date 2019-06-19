using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadController : MonoBehaviour
{
    public List<GameObject> safeRoads;
    public List<GameObject> roadBlocks;
    private List<GameObject> activeRoads;

    public Text txt;

    private float roadLength = 60f;
    private float spawnPosZ = 10.0f;
    private float safeZone = 120f;

    private int AMOUNT_ROADS_ON_SCREEN = 5;
    private int lastPrefabIndex = 0;

    public Transform playerTransform;

    // Use this for initialization
    void Start()
    {
        activeRoads = new List<GameObject>();
        SpawnSafeRoads();
    }

    private void DestroyRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnPosZ - AMOUNT_ROADS_ON_SCREEN * roadLength))
        {
            SpawnRandomRoad();
            DestroyRoad();
        }
    }

    private void SpawnRandomRoad()
    {
        GameObject _roadClone;
        _roadClone = Instantiate(roadBlocks[RandomPrefabIndex()]) as GameObject;
        _roadClone.transform.SetParent(transform);
        _roadClone.transform.position = Vector3.forward * spawnPosZ;
        spawnPosZ += roadLength;
        activeRoads.Add(_roadClone);
    }


    private void SpawnSafeRoads()
    {
        GameObject roadBlock;

        for (int i = 0; i < safeRoads.Count; i++)
        {
            roadBlock = Instantiate(safeRoads[i]) as GameObject;
            roadBlock.transform.SetParent(transform);
            roadBlock.transform.position = Vector3.forward * spawnPosZ;
            spawnPosZ += roadLength;
            activeRoads.Add(roadBlock);
        }

    }

    private int RandomPrefabIndex()
    {
        if (roadBlocks.Count <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = UnityEngine.Random.Range(0, roadBlocks.Count);
        }

        lastPrefabIndex = randomIndex;
        // Debug.Log(randomIndex);
        txt.text = "Index\n" + randomIndex;
        return randomIndex;
    }
}