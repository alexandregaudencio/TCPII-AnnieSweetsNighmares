using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoTeste : MonoBehaviour
{
    public float timeValue = 90;
    public Text timerText;

    public static TempoTeste tempoTesteInstante;

    public void Start()
    {
        tempoTesteInstante = this;
    }
    void Update()
    {
        if (timeValue > 0 )
        {
            if (ControleSpawnUrso.instance.IsGameplayOn)
                timeValue -= Time.deltaTime;

        }
        else
        {
            //timeValue = 0;
            ControleSpawnUrso.instance.IsGameplayOn = false;
            gameManager.instance.vitoria();
        }
        DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text =string.Format("{0:00}:{1:00}", minutes ,seconds);
    }
}
