using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsWaveController : MonoBehaviour
{
    public int CurrentWaveNumber { get; private set; }

    [SerializeField]
    float WaveDuration = 20f;

    [SerializeField]
    float CooldownDuration = 5f;

    [SerializeField]
    float BreakDuration = 5f;

    public event System.Action<int> OnWaveStarted;
    public event System.Action<int> OnWaveEnded;

    // Use this for initialization
    void Start()
    {
        CurrentWaveNumber = 1;
        StartCoroutine(AsteroidsWaveControllerCoroutine());
    }
    
    private IEnumerator AsteroidsWaveControllerCoroutine()
    {
        var spawner = FindObjectOfType<AsteroidSpawner>();

         while(true)
        {
            if (OnWaveStarted != null)
            {
                OnWaveStarted.Invoke(CurrentWaveNumber);
            }

            spawner.AsteroidTypeLevel = CurrentWaveNumber;
     
            spawner.Spawning = true;
            yield return new WaitForSeconds(WaveDuration);

            spawner.Spawning = false;
            yield return new WaitForSeconds(CooldownDuration);

            if (OnWaveEnded != null)
            {
                OnWaveEnded.Invoke(CurrentWaveNumber);
            }

            yield return new WaitForSeconds(BreakDuration);

            CurrentWaveNumber++;
        }
    }
}
