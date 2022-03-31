using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePause : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUI;
    [SerializeField] GameObject CreditsUI;

    bool GameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        CreditsUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ReturnToMenu()
    {
        ScManager.self.ChangeScene("Character Selection");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
