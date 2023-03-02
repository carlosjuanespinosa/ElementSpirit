
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StatsPlayers", menuName = "ScriptableObjects/StatsPlayers")]

public class StatsPlayers : ScriptableObject
{
    public float daño { get; private set; }

    public event Action Changed;

   public void OnEnable()
    {
        daño = 0;
    }

    public void DamagePlayer(float amount)
    {
        daño += amount;
        Changed?.Invoke();
    }
    public void Respawn()
    {
        daño = 0;
        Changed?.Invoke();
    }
}
