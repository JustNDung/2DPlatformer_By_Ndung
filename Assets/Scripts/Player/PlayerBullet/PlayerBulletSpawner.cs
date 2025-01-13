using UnityEngine;

public class PlayerBulletSpawner : BulletSpawner
{
    public override void SpawnBullet(Vector2 position, Vector2 direction)
    {
        BulletBase bullet = bulletPool.Get();
        bullet.transform.position = position;
        bullet.transform.rotation = Quaternion.identity;

        bullet.SetPool(bulletPool);
        bullet.Launch(direction, bulletSpeed);
    }
}
