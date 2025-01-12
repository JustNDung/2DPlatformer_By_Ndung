using UnityEngine;

public interface IDamager
{
    float DamageAmount { get; } // Số sát thương gây ra
    void DealDamage(IDamageable target); // Gây sát thương cho mục tiêu
    
}

