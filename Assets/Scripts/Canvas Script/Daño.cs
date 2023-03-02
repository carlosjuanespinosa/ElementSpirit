using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Daño : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextoDaño;
    [SerializeField] private StatsPlayers StatsEnemigo;
    // Start is called before the first frame update
    private void Awake() => StatsEnemigo.Changed += UpdateText;

    private void OnDestroy() => StatsEnemigo.Changed -= UpdateText;

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        TextoDaño.SetText(StatsEnemigo.daño.ToString());
    }
}
