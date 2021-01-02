using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;

    private bool _canPause = true;

    private void OnEnable()
    {
        Special.GameOver += OnGameOver;
    }
    private void OnDisable()
    {
        Special.GameOver -= OnGameOver;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            _gameMenu.SetActive(!_gameMenu.activeSelf);
            if (_canPause)
            {
                if (Time.timeScale < 1)
                    Time.timeScale = 1;
                else
                    Time.timeScale = 0;
            }
        }
    }
    public void ActiveGameMenu()
    {
        _gameMenu.gameObject.SetActive(true);
    }
    private void OnGameOver(string text)
    {
        _gameMenu.SetActive(true);
        _canPause = false;
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitFromGame()
    {
        Application.Quit();
    }
}
