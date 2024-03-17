using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private float respawnDelay = 1.4f;
    public bool isGameEnd;

    public TextMeshProUGUI uIText;
    public TextMeshProUGUI scoreText;
    public Button fixButton;


    public GameObject endScreen;

    public Point[] points;

    public AudioClip doorOpen;


    private void Awake()
    {
        AudioListener.volume = 1f;
    }
    public void CompliteLevel()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ShowEndScreen()
    {
        isGameEnd = true;
        this.GetComponent<AudioSource>().PlayOneShot(doorOpen);
        scoreText.text = Score.scoreValue.ToString();
        endScreen.SetActive(true);
        AudioListener.volume = 0f;
    }

    public void Restart()
    {
        Score.scoreValue = 0;
        AudioListener.volume = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        AudioListener.volume = 1f;
        SceneManager.LoadSceneAsync(0);
    }
    public void LevelUp()
    {
        //   WinnerIU.SetActive(true);
        Invoke("NextLevel", 2f);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    

    public IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameEnd = false;
    }
}
