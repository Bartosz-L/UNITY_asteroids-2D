using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    AsteroidType[] AsteroidTypes;

    [SerializeField]
    GameObject AsteroidPrefab;

    [SerializeField]
    float AsteroidSpawningTime = 2f;

    public int AsteroidTypeLevel { get; set; }
    public int AsteroidTypeRange { get; set; }


    public bool Spawning = true;

    // Use this for initialization
    void Start()
    {
        AsteroidTypeLevel = 0;
        AsteroidTypeRange = 5;

        StartCoroutine(SpawningCoroutine());
    }

    IEnumerator SpawningCoroutine()
    {
        while(true)
        {
            // while spawning can be done, spawn asteroids and wait for spawning time
            while(Spawning)
            {
                SpawnAsteroid();
                yield return new WaitForSeconds(AsteroidSpawningTime); 

            }
            // wait for frame for better performance
            yield return new WaitForEndOfFrame();
        }
    }

    private AsteroidType GetRandomAsteroidType()
    {
        var index = AsteroidTypeLevel + Random.Range(-AsteroidTypeRange, AsteroidTypeRange);
        // make sure index is in range od asteroidtypes array
        index = Mathf.Clamp(index, 0, AsteroidTypes.Length - 1);
        return AsteroidTypes[index];
    }

    private void SpawnAsteroid()
    {
        // instantiate prefab
        var obj = Instantiate(AsteroidPrefab, transform.position, Quaternion.identity);
        // randomize prefab position
        obj.transform.position += Vector3.right * Random.Range(-2f, 2f);

        var asteroidType = GetRandomAsteroidType();
        obj.GetComponent<Asteroid>().Configure(asteroidType);
    }
}
