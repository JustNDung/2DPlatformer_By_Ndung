using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab; // Prefab của viên đạn
    [SerializeField] private int initialBulletCount = 10; // Số lượng đạn ban đầu
    [SerializeField] private float bulletSpeed = 10f;
    private GenericObjectPool<Bullet> bulletPool;
    private PlayerController playerController;
    private void Start()
    {
        // Khởi tạo Object Pool cho đạn
        playerController = GetComponentInParent<PlayerController>();
        bulletPool = new GenericObjectPool<Bullet>(bulletPrefab, initialBulletCount);
    }

    public void SpawnBullet(Vector2 position, Vector2 direction)
    {
        // Lấy một viên đạn từ Pool
        Bullet bullet = bulletPool.Get();
        // Đặt vị trí và hướng của viên đạn
        bullet.transform.position = position;
        // Gắn Object Pool cho viên đạn
        bullet.SetPool(bulletPool);
        // Thêm lực để bắn đạn
        bullet.Launch(direction, bulletSpeed);
    }
}
