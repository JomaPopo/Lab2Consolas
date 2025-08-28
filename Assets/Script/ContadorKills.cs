using UnityEngine;
using TMPro;

public class ContadorKills : MonoBehaviour
{
    public TMP_Text textoKills;
    public int kills = 0;

    void Start()
    {
        ActualizarTexto();
    }

    public void AumentarKill()
    {
        kills += 1;
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        if (textoKills != null)
            textoKills.text = kills.ToString();
    }
}
