using UnityEngine;

public class CastCollider : HitBox
{
    [SerializeField] private BringerOfDeath bringerOfDeath;
    [SerializeField] private float offset;
    
    [SerializeField] private SpellCollider spellCollider;
    [SerializeField] private int spellAmount = 10;
    [SerializeField] private float duration;
    
    private GenericObjectPool<SpellCollider> spellPool;

    private void Awake()
    {
        // Khởi tạo pool với spellCollider prefab
        spellPool = new GenericObjectPool<SpellCollider>(spellCollider, spellAmount, null, duration);
    }

    private void OnDisable()
    {
        target = null;
    }

    public void Cast()
    {
        Spell();
    }

    private void Spell()
    {
        PlayerController player = target as PlayerController;
        if (player != null)
        {
            // Xác định vị trí để spawn spell
            Vector3 spellPos = new Vector3(player.transform.position.x, transform.position.y + offset, transform.position.z);
            // Lấy spell từ pool
            SpellCollider spell = spellPool.Get();

            if (spell != null)
            {
                // Đặt vị trí và hướng cho spell
                spell.transform.position = spellPos;
                spell.transform.rotation = Quaternion.identity;
            }
        }
    }
}