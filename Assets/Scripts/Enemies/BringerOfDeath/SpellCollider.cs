using UnityEngine;

public class SpellCollider : HitBox
{
    [SerializeField] private BringerOfDeath bringerOfDeath;
    [SerializeField] private float destroyAfterSeconds = 5f; // Thời gian tự hủy
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void DealSpellDamage()
    {
        bringerOfDeath.DealDamage(target);
    }
}