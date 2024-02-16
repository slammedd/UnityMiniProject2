using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float time;
    public TextMeshProUGUI timerText;
    public bool stopped;

    // Update is called once per frame
    void Update()
    {
        if(stopped == false)
        {
            time += Time.deltaTime;
            timerText.text = time.ToString("F0");
        }
    }
}
