using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class LizardBulletSpawner : BulletSpawner
{
    [SerializeField] private float offset = 2f;
    [SerializeField] private int amount = 2;
    public override void SpawnBullet(Vector2 spawnPos, Vector2 direction)
    {
        for (int i = 0; i < amount; i++) 
        {
            // Lấy viên đạn từ pool
            BulletBase bullet = bulletPool.Get();
            bullet.transform.position = spawnPos;
            bullet.transform.rotation = Quaternion.identity;

            spawnPos.x += direction.x * offset;
            // Thiết lập và bắn đạn
            bullet.SetPool(bulletPool);
            bullet.Launch(direction, bulletSpeed);
        }
    }
}