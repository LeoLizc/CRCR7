using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScene : MonoBehaviour
{
    public TMP_Text best_time;
    public TMP_Text time;

    void Awake()
    {
        best_time.SetText("Mejor tiempo " + GameManager.Instance.getBestTime());
        time.SetText("Tu tiempo " + GameManager.Instance.getLastTime());
    }
}
