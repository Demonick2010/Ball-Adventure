using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject outPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.gameObject.transform.position = outPoint.transform.position;
    }
}
