using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManage : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameOverMenu;
    public GameObject inGameMenu;
    public GameObject stats;


    public static MenuManage instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        ReturnToMainMenu();
        
    }

    public void OpenMainMenu()
    {
        instance.mainMenu.SetActive(true);
        instance.inGameMenu.SetActive(false);
        Time.timeScale = 0;

    }

    public static void OpenGameOver()
    {
        instance.gameOverMenu.SetActive(true);
        instance.inGameMenu.SetActive(false);
        Time.timeScale = 0;
        UIManager.UpdateHighscore();
        
        
        
    }

    public void OpenInGame()
    {
        instance.mainMenu.SetActive(false);
        instance.gameOverMenu.SetActive(false);
        instance.inGameMenu.SetActive(true);
        Time.timeScale = 1;
        UIManager.UpdateHighscore();
        UIManager.CountGames();
        GameManager.SpawnNewWave();
    }

    public void ReturnToMainMenu()
    {
        instance.gameOverMenu.SetActive(false);
        instance.inGameMenu.SetActive(false);
        instance.mainMenu.SetActive(true);
        instance.stats.SetActive(false);
        Time.timeScale = 0;
        GameManager.CancelGame();
        
    }

    public void OpenStats()
    {
        instance.mainMenu.SetActive(false);
        instance.stats.SetActive(true);
        UIManager.UpdateHighscore();

    }

}

