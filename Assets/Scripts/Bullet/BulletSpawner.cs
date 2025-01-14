using UnityEngine;

public abstract class BulletSpawner : MonoBehaviour
{
    [SerializeField] protected BulletBase bulletPrefab; // Prefab của viên đạn
    [SerializeField] protected int initialBulletCount = 10; // Số lượng đạn ban đầu
    [SerializeField] protected float bulletSpeed = 15f;
    protected GenericObjectPool<BulletBase> bulletPool;
    private void Awake()
    {
        // Khởi tạo Object Pool cho đạn
        bulletPool = new GenericObjectPool<BulletBase>(bulletPrefab, initialBulletCount);
    }
    
    public abstract void SpawnBullet(Vector2 position, Vector2 direction);
}
