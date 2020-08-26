﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    public void Countinue()
    {
        // Если есть сохраненная игра - кнопка активна, продолжает игру (interactable set active)
    }
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Добавить функционал создания новой игры
    }
    public void ResetProgress()
    {
        // Добавить функционал удаления сохранения
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
