using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnPlatformObjects;

    void Start()
    {
        Instantiate(SpawnPlatformObjects[Random.Range(0, SpawnPlatformObjects.Length)], transform.position, Quaternion.identity);
    }
}
