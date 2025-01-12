using UnityEngine;
using System.Collections;

public class SlimeBehavior : MonoBehaviour, IDamageable
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {

    }

    private IEnumerator BlinkAndDestroy() {

        float blinkDuration = 1.5f; // Tổng thời gian nhấp nháy
        float blinkInterval = 0.1f; // Khoảng thời gian giữa mỗi lần nhấp nháy
        float elapsedTime = 0f;

        while (elapsedTime < blinkDuration) {
            // Chuyển đổi trạng thái hiển thị
            spriteRenderer.enabled = !spriteRenderer.enabled;

            elapsedTime += blinkInterval;
            yield return new WaitForSeconds(blinkInterval);
        }

        // Đảm bảo Slime ẩn hoàn toàn trước khi bị phá hủy
        spriteRenderer.enabled = false;

        // Phá hủy đối tượng Slime
        Destroy(gameObject);
    }

    public void TakeDamage() {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với Player
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform playerTransform = collision.gameObject.transform;

            if (transform.DotTest(playerTransform, Vector2.up))
            {
                StartCoroutine(BlinkAndDestroy());
            }
        }
    }

}
