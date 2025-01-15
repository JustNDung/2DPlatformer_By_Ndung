using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class LizardBulletSpawner : BulletSpawner
{
    [SerializeField] private float lizardOffset = 1f;
    [SerializeField] private int lizardAmount = 3;

    private void Start()
    {
        offset = lizardOffset;
        amount = lizardAmount;
    }
}