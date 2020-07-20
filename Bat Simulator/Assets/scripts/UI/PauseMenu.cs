using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    
    private PauseInput input;
    
    private void Awake()
    {
        input = new PauseInput();
        input.PauseMenu.Pause.performed += ctx => PauseGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Debug.Log("Called.");
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        Debug.Log(Time.timeScale);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
