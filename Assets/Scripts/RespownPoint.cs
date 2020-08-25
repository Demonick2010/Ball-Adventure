using UnityEngine;

public class RespownPoint : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        SpawnPivot();
    }

    public void Spawn()
    {
        Vector3 spawnPointTransform = transform.position;
        spawnPointTransform.y += 0.3f;

        Instantiate(gameManager.PlayerPrefab, spawnPointTransform, Quaternion.identity);
    }

    public void SpawnPivot()
    {
        Vector3 spawnPointTransform = transform.position;

        float x = spawnPointTransform.x + 2.3f;
        float y = spawnPointTransform.y + 1.5f;
        float z = spawnPointTransform.z + 1.5f;

        // Set needed values
        spawnPointTransform = new Vector3(x, y, z);

        Instantiate(gameManager.PivotPrefab, spawnPointTransform, Quaternion.identity);
    }
}
