using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;

    public GameObject[] FruitPrefabs;

    public float MinSpawnDelay = 0.25f;
    public float MaxSpawnDelay = 1f;
    public float MinAngle = -15f;
    public float MaxAngle = 15f;
    public float MinForce = 18f;
    public float MaxForce = 22f;
    public float MaxLifeTime = 5f;

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
        {
            GameObject prefab = FruitPrefabs[Random.Range(0, FruitPrefabs.Length)];

            Vector3 position = new Vector3();
            position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(MinSpawnDelay, MaxSpawnDelay));

            GameObject fruit = Instantiate(prefab, position, rotation);
            Destroy(fruit, MaxLifeTime);

            float force = Random.Range(MinForce, MaxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(MinSpawnDelay, MaxSpawnDelay));
        }
    }
}
