using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public VoidEventChannel onPlayerDeath;
    public PlayerData playerData;
    private void Awake(){
        pauseMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
    }
private void OnEnable(){
    onPlayerDeath.OnEventRaised += Die;
}

    private void Die()
    {
        gameOverUI.SetActive(true);
    }

    private void OnDisable(){
        onPlayerDeath.OnEventRaised -= Die;
    }

    public void Pause(){
        isGamePaused = true;
        Time.timeScale = 0;
        pauseMenuUI.SetActive(isGamePaused);
    }

    public void Resume(){
        isGamePaused = false;
                Time.timeScale = 1;
        pauseMenuUI.SetActive(isGamePaused);
    }
    public void Quit(){
        Application.Quit();
        Debug.Log("Quit Game");
    }
    public void ReloadScene(){
                Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            ReloadScene();
        }
        if(playerData.currentLifePoints > 0 &&
        Input.GetKeyDown(KeyCode.Escape)){
            TogglePause();
        }
    }

    public void TogglePause(){
        // isGamePaused = !isGamePaused;
        if(isGamePaused){
            Resume();
        }else{
            Pause();
        }
    }
}
