using UnityEngine;

public abstract class HitBox : MonoBehaviour
{
    public IDamageable target;
    
    private void OnTriggerEnter2D(Collider2D collision) // Đổi từ `public` -> `private`
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null && collision.CompareTag("Player"))
        {
            target = damageable;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null && collision.CompareTag("Player"))
        {
            target = null;
        }
    }
}