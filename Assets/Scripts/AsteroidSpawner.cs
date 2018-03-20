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

	void Start ()
    {
        AsteroidTypeLevel = 0;
        AsteroidTypeRange = 5;

        StartCoroutine(SpawningCoroutine());
	}

    IEnumerator SpawningCoroutine()
    {
        while(true)
        {
            while(Spawning)
            {
                SpawnAsteroid();
                yield return new WaitForSeconds(AsteroidSpawningTime);
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private AsteroidType GetRandomAsteroidType()
    {
        var index = AsteroidTypeLevel + Random.Range(-AsteroidTypeRange, AsteroidTypeRange);
        index = Mathf.Clamp(index, 0, AsteroidTypes.Length - 1);

        return AsteroidTypes[index];
    }

    private void SpawnAsteroid()
    {
        var obj = Instantiate(AsteroidPrefab, transform.position, Quaternion.identity);
        obj.transform.position += Vector3.right * Random.Range(-2f, 2f);

        var asteroidType = GetRandomAsteroidType();
        obj.GetComponent<Asteroid>().Configure(asteroidType);
    }
}
