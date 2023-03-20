
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StatsPlayers", menuName = "ScriptableObjects/StatsPlayers")]

public class StatsPlayers : ScriptableObject
{
    public float daño { get; private set; }
    public float kills { get; private set; }

    public event Action Changed;

   public void OnEnable()
    {
        daño = 0;
        kills = 0;
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

    public void ContKills(float amount)
    {
        kills += amount;
        Changed?.Invoke();

    }
}
