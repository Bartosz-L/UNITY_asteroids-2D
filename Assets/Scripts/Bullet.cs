using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CannonType {  Single, Double, Triple }

[System.Serializable]
public class BulletType
{
    public CannonType cannonType = CannonType.Single;

    public Sprite Sprite;
    public float ShootingDuration = 0.25f;
    public float Power = 1f;
    public float Speed = 6f;
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour
{
    public float Power = 1f;

    public void Configure(BulletType bulletType)
    {
        Power = bulletType.Power;

        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bulletType.Sprite;

        var rigidbody = GetComponent<Rigidbody2D>();
        // give velocity to an object - angle, direction and speed
        rigidbody.velocity = transform.rotation * Vector3.up * bulletType.Speed;
    }
}
