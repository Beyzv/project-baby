using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Text timerText;
    [SerializeField]
    float remainigTime;

    public GameManager gameManager;
    void Update()
    {
        if (remainigTime > 0)
        {
            remainigTime -= Time.deltaTime;
        }
        else if (remainigTime < 0)
        {
            remainigTime = 0;
            gameManager.LevelUp();
        }

        int minutes = Mathf.FloorToInt(remainigTime / 60);
        int seconds = Mathf.FloorToInt(remainigTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
