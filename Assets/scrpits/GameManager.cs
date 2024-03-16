using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private float respawnDelay = 1.4f;
    private bool isGameEnd;
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
