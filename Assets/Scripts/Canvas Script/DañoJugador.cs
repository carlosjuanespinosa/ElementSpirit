using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DañoJugador : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextoDaño;
    [SerializeField] private StatsPlayers StatsJugador;
    // Start is called before the first frame update
    private void Awake() => StatsJugador.Changed += UpdateText;

    private void OnDestroy() => StatsJugador.Changed -= UpdateText;

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        TextoDaño.SetText(StatsJugador.daño.ToString());
    }
}
