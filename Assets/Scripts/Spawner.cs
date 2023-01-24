using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();

    }
}
