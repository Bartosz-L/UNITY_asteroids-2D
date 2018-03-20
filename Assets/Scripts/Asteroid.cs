using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AsteroidType
{
    public Sprite Sprite;
    public float Durability = 5f;
    public int Points = 10;
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    float Durability = 6f;

    [SerializeField]
    GameObject DestroyingParticles;

    [SerializeField]
    GameObject DestroyedParticles;

    private int Points;

    private SpriteRenderer SpriteRenderer;

    // Use this for initialization
    void Awake ()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SetSpeed();
    }

    private void SetSpeed()
    {
        var targetSpeed = Random.Range(2f, 5f);

        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.down * targetSpeed;
    }
    
    public void Configure(AsteroidType asteroidType)
    {
        SpriteRenderer.sprite = asteroidType.Sprite;
        Durability = asteroidType.Durability;
        Points = asteroidType.Points;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject;
        var bullet = obj.GetComponent<Bullet>();

        // if collided with bullet, decrease durability of asteroid and destroy bullet
        if (bullet != null)
        {
            GenerateParticles(DestroyingParticles, collision.transform.position);
            DecreaseDurability(bullet.Power);
            Destroy(obj);
        }
    }

    private void DecreaseDurability(float amount)
    {
        Durability -= amount;

        // if durability reaches 0, destroy asteroid
        if (Durability <= 0)
        {
            GenerateParticles(DestroyedParticles, transform.position);
            
            FindObjectOfType<GameManager>().Money += Points;
            Destroy(gameObject);
        }

    }

    private void GenerateParticles(GameObject prefab, Vector3 position)
    {
        var particles = Instantiate(prefab, position, Quaternion.identity);
        particles.GetComponent<ParticleSystemRenderer>().material.mainTexture = SpriteRenderer.sprite.texture;
    }
}
