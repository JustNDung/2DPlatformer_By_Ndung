using UnityEngine;

public class CastCollider : HitBox
{
    [SerializeField] private BringerOfDeath bringerOfDeath;
    [SerializeField] private float offset;
    [SerializeField] private GameObject spell;

    public void Cast()
    {
        Spell();
    }

    private void Spell()
    {
        PlayerController player = target as PlayerController;
        if (player != null)
        {
            Vector3 spellPos = new Vector3(player.transform.position.x, transform.position.y + offset, transform.position.z);
            Instantiate(spell, spellPos, Quaternion.identity);
        }
    }
}
