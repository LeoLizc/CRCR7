using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    private float StartTime;
    private float tiempo;
    public Text textoTiempo;

    void Start()
    {
        StartTime = Time.time;
        textoTiempo.text = "00:00:00";
    }


    void Update () 
    {
        if (GameManager.Instance.state == GameManager.GameState.start)
        {
            StartTime = Time.time;
        }
        else if (GameManager.Instance.state == GameManager.GameState.running)
        {
            tiempo = Time.time - StartTime;
            string mins = ((int)tiempo/60).ToString("00");
            string segs = (tiempo % 60).ToString("00");
            string milisegs = ((tiempo * 100)%100).ToString ("00");
                
            string TimerString = string.Format ("{00}:{01}:{02}", mins, segs, milisegs);
                
            textoTiempo.text = TimerString.ToString ();
        }
        else if (GameManager.Instance.state == GameManager.GameState.crashed)
        {
            GameManager.Instance.esMejorTiempo(tiempo, textoTiempo.text);
        }
	}
}
