using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LineSpawner : MonoBehaviour
{
    [SerializeField] private float timeBetweenSpawns = 1.5f;
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Vector2 lineStart, lineEnd;
    
    [SerializeField] private float currentSpawnTime = 0;
    
    private void Update()
    {
        currentSpawnTime += Time.deltaTime;
        if (currentSpawnTime >= timeBetweenSpawns)
        {
            Instantiate(objectToSpawn, Vector2.Lerp(lineStart, lineEnd, Random.Range(0.0f, 1.0f)), Quaternion.identity);
            currentSpawnTime = 0.0f;
        }
    }
}
