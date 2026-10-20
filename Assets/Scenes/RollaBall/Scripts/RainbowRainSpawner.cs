
using UnityEngine;
using System.Collections;

public class RainbowRainSpawner : MonoBehaviour
{
    [Header("Sphere Prefab")]
    public GameObject spherePrefab;

    [Header("Rain Settings")]
    public float spawnInterval = 0.2f;
    public float spawnHeight = 8f;
    public float spawnRangeX = 4f;
    public float spawnRangeZ = 4f;

    [Header("Random Sphere Sizes")]
    public float minSize = 0.3f;
    public float maxSize = 0.7f;

    void Start()
    {
        // Start the repeating rain effect.
        StartCoroutine(SpawnRain());
    }

    IEnumerator SpawnRain()
    {
        while (true)
        {
            if (spherePrefab != null)
            {
                // Generate a random position above the board.
                float randomX = Random.Range(
                    -spawnRangeX, spawnRangeX
                );

                float randomZ = Random.Range(
                    -spawnRangeZ, spawnRangeZ
                );

                Vector3 spawnPosition = transform.position +
                    new Vector3(randomX, spawnHeight, randomZ);

                // Create a new sphere.
                GameObject newSphere = Instantiate(
                    spherePrefab,
                    spawnPosition,
                    Quaternion.identity
                );

                // Give the sphere a random size.
                float randomSize = Random.Range(
                    minSize, maxSize
                );

                newSphere.transform.localScale =
                    Vector3.one * randomSize;
            }

            // Wait before creating the next sphere.
            yield return new WaitForSeconds(
                Mathf.Max(0.02f, spawnInterval)
            );
        }
    }
}
