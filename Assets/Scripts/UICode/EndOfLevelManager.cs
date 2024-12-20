using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfLevelManager : MonoBehaviour
{
    //Reference to the EndOfLevelPrefab
    public GameObject endOfLevelMenu;
    public GameObject pauseMenu;
    public GameObject chooseMenu;
    public GameObject howToPc;
    public GameObject howToMobile;
    public GameObject gameOverlay;
    public GameObject gameOver;
    public GameObject pointers;
    //public GameObject hitBox;




    //public GameObject inGameDisplay;

    //Bool to check if the game is paused
    public static bool Paused = false;


    // Start is called before the first frame update
    void Start()
    {
        //Sets the timescale to 1
        Time.timeScale = 1f;
    }

    /*private void OnEnable()
    {
        Collectible.OnCollected += OnCollectibleCollected;
    }

    private void OnDisable()
    {
        Collectible.OnCollected += OnCollectibleCollected;
    }

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();
    }*/
    // Update is called once per frame
    /*void Update()
    {
        //If you press the escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If the game is paused
            if (Paused)
            {
                //The game resumes
                Play();
            }
            //If the game is not paused
            else
            {
                //The game is paused
                Finish();
            }
        }
    }*/

    //Function for pausing the game
    public void Finish()
    {
        //Activates the pause menu
        endOfLevelMenu.SetActive(true);

        //hitBox.SetActive(false);

        //Deactivates the HUD
        gameOverlay.SetActive(false);
        //Freezes time
        Time.timeScale = 0f;
        //Pauses the game
        Paused = true;

    }
    //Function for resuming the game
    public void Play()
    {
        //Deactivates the pause menu
        endOfLevelMenu.SetActive(false);
        //Resumes the time
        Time.timeScale = 1f;
        //Unpauses the game
        Paused = false;
    }

    //Function for going to the main menu
    public void ResetLevel()
    {
        //Resumes the time
        Time.timeScale = 1f;
        //Unpauses the game
        Paused = false;
        //Loads the main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void NextLevel()
    {
        //Resumes the time
        Time.timeScale = 1f;
        //Unpauses the game
        Paused = false;
        //Loads the main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuButton()
    {
        //Resumes the time
        Time.timeScale = 1f;
        //Unpauses the game
        Paused = false;
        //Loads the main menu
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseMenu()
    {
        //Activates the pause menu
        pauseMenu.SetActive(true);

        //Deactivates the HUD
        gameOverlay.SetActive(false);
        //Freezes time
        Time.timeScale = 0f;
        //Pauses the game
        Paused = true;

    }

    public void UnPause()
    {
        //Activates the pause menu
        pauseMenu.SetActive(false);

        //Deactivates the HUD
        gameOverlay.SetActive(true);
        //UnFreezes time
        Time.timeScale = 1f;
        //Pauses the game
        Paused = false;
    }

    public void SettingsMenu()
    {
        //Resumes the time
        Time.timeScale = 1f;
        //Unpauses the game
        Paused = false;
        //Loads the main menu
        SceneManager.LoadScene("SettingsMenu");
    }
 
    public void LevelsMenu()
    {
        //Resumes the time
        Time.timeScale = 1f;
        //Unpauses the game
        Paused = false;
        //Loads the main menu
        SceneManager.LoadScene("LevelsMenu");
    }
    public void HowToPlayButton()
    {
        //Activates the pause menu
        chooseMenu.SetActive(true);
        //Freezes time
        Time.timeScale = 0f;
        //Pauses the game
        Paused = true;
    }

    public void PCButton()
    {
        //Activates the pause menu
        howToPc.SetActive(true);
        //Freezes time
        Time.timeScale = 0f;
        //Pauses the game
        Paused = true;
    }

    public void MobileButton()
    {
        //Activates the pause menu
        howToMobile.SetActive(true);
        //Freezes time
        Time.timeScale = 0f;
        //Pauses the game
        Paused = true;
    }


    public void GameOver()
    {
   
        //Activates GameOverMenu
        gameOver.SetActive(true);
        //Deactivates the HUD
        gameOverlay.SetActive(false);
        //Deactivates the Pointers
        pointers.SetActive(false);
        //Freezes time
        Time.timeScale = 0f;
        //Pauses the game
        Paused = true;
    }

    //Quit game
    public void EndGame()
    {
        Application.Quit();
    }

}
