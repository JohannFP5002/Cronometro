using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timerText;

    private float Timer;
    private bool corriendo;
    private int centesimas, segundos, minutos , horas;
    public Button PausarReanudarBoton;
    public Button ReiniciarBoton;

    private void Start()
    {
        Timer = 0f;
        corriendo = false;
        PausarReanudarBoton.onClick.AddListener(PausarReanudar);
        ReiniciarBoton.onClick.AddListener(Reiniciar);

    }

    void Update()
    {
        if (corriendo)
        {
            Timer += Time.deltaTime;
            ActualizarTiempo();
        }
    }
    public void PausarReanudar()
    {
        corriendo = !corriendo;
    }
    public void Reiniciar()
    {
        corriendo = false;
        Timer = 0f;
        ActualizarTiempo() ;

    }
    private void ActualizarTiempo()
    {
        horas = (int)(minutos / 60f);
        minutos = (int)(Timer / 60f);
        segundos = (int)(Timer - minutos * 60f);
        centesimas = (int)((Timer - (int)Timer) * 100f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", horas, minutos, segundos, centesimas);
    }
}
