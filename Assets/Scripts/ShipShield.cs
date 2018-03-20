using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ShipShield : MonoBehaviour, IUpgradable
{
    [SerializeField]
    Sprite[] ShieldStates;

    bool Active
    {
        get { return CurrentState > 0; }
    }

    #region IUpgradable

    public int MaxLevel
    {
        get { return ShieldStates.Length - 1; }
    }

    public int CurrentLevel { get; private set; }

    public int UpgradeCost
    {
        get { return CurrentLevel * 50 + 100; }
    }

    public void Upgrade()
    {
        CurrentLevel += 1;
        Rebuild();
    }

    #endregion

    int currentState = 0;
    public int CurrentState
    {
        get { return currentState; }
        set
        {
            currentState = Mathf.Clamp(value, 0, MaxLevel);
            UpdateSprite();
        }
    }

    private void Awake()
    {
        FindObjectOfType<AsteroidWaveController>().OnWaveStarted += _ => Rebuild();
    }

    private void Start()
    {
        Rebuild();
    }

    private void Rebuild()
    {
        CurrentState = CurrentLevel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var asteroid = collision.gameObject.GetComponent<Asteroid>();

        if (asteroid == null)
            return;

        if (!Active)
            return;

        CurrentState -= 1;
        Destroy(asteroid.gameObject);
    }

    private void UpdateSprite()
    {
        GetComponent<SpriteRenderer>().sprite = ShieldStates[CurrentState];
    }
}
