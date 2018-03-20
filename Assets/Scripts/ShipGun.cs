using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ShipGun : MonoBehaviour, IUpgradable
{
    [SerializeField]
    GameObject BulletPrefab;

    [SerializeField]
    BulletType[] BulletTypes;

    float LastShootTime = 0f;

    BulletType BulletType
    {
        get { return BulletTypes[CurrentLevel]; }
    }

    [SerializeField]
    AudioClip FireClip;

    private AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = FireClip;
    }


    #region IUpgradable

    public int MaxLevel
    {
        get { return BulletTypes.Length - 1; }
    }

    public int CurrentLevel { get; set; }

    public int UpgradeCost
    {
        get { return CurrentLevel * 50 + 25; }
    }

    public void Upgrade()
    {
        CurrentLevel += 1;
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0)) return;
        if (!CanShootBullet()) return;

        ShootBullets();

        // update time of last shoot
        LastShootTime = Time.timeSinceLevelLoad;

    }

    private void ShootBullets()
    {
        if (BulletType.cannonType == CannonType.Single)
        {
            ShootBullet(Vector3.zero, Vector3.zero);
        }

        else if (BulletType.cannonType == CannonType.Double)
        {
            ShootBullet(Vector3.left * 0.1f, Vector3.forward * 5f);
            ShootBullet(Vector3.right * 0.1f, Vector3.back * 5f);
        }
        else if (BulletType.cannonType == CannonType.Triple)
        {
            ShootBullet(Vector3.left * 0.1f, Vector3.forward * 15f);
            ShootBullet(Vector3.zero, Vector3.zero);
            ShootBullet(Vector3.right * 0.1f, Vector3.back * 15f);
        }

        AudioSource.Play();
    }

    private void ShootBullet(Vector3 position, Vector3 rotation)
    {
        // instantiate bullet at given position

        var bullet = Instantiate(
                BulletPrefab,
                transform.position + position + Vector3.up * 0.5f,
                Quaternion.Euler(rotation));

        // configure bullet using configure method from Bullet class
        bullet.GetComponent<Bullet>().Configure(BulletType);
    
    }

    private bool CanShootBullet()
    {
        return (Time.timeSinceLevelLoad - LastShootTime > BulletType.ShootingDuration);
    }

}
