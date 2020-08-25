using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnPlatformObjects;

    void Start()
    {
        Instantiate(SpawnPlatformObjects[UnityEngine.Random.Range(0, SpawnPlatformObjects.Length)], transform.position, Quaternion.identity);
    }
}
