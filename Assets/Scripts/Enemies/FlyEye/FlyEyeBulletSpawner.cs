using UnityEngine;

public class FlyEyeBulletSpawner : BulletSpawner
{
    [SerializeField] private float playerOffset = 0f;
    [SerializeField] private int playerAmount = 1;
    
    private void Start()
    {
        offset = playerOffset;
        amount = playerAmount;
    }
    
}