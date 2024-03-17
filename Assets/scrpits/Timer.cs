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

    public AudioSource hurryAus;
    public AudioSource slowAus;

    public GameManager gameManager;

    public AudioClip fastSoundtrack;
    void Update()
    {
        
        if (remainigTime > 0)
        {
            remainigTime -= Time.deltaTime;
            if (remainigTime < 60 && !hurryAus.isPlaying)
            {
                slowAus.Stop();
                hurryAus.Play();
                timerText.color = Color.red;
                timerText.transform.GetComponent<Animator>().SetTrigger("Hurry");
            }
            
        }
        else if (remainigTime < 0 && !gameManager.isGameEnd)
        {
            remainigTime = 0;
            gameManager.ShowEndScreen();
        }

        int minutes = Mathf.FloorToInt(remainigTime / 60);
        int seconds = Mathf.FloorToInt(remainigTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
