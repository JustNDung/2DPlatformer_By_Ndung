using UnityEngine;

public abstract class BulletSpawner : MonoBehaviour
{
    [SerializeField] protected BulletBase bulletPrefab; // Prefab của viên đạn
    [SerializeField] protected int initialBulletCount = 10; // Số lượng đạn ban đầu
    [SerializeField] protected float bulletSpeed = 15f;
    
    protected int amount = 1;
    protected float offset = 1f;
    
    protected GenericObjectPool<BulletBase> bulletPool;
    private void Awake()
    {
        // Khởi tạo Object Pool cho đạn
        bulletPool = new GenericObjectPool<BulletBase>(bulletPrefab, initialBulletCount);
    }
    
    public void SpawnBullet(Vector2 spawnPos, Vector2 direction)
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
