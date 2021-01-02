using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;

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
            _gameMenu.SetActive(!_gameMenu.activeSelf);
    }
    public void ActiveGameMenu()
    {
        _gameMenu.gameObject.SetActive(true);
    }
    private void OnGameOver(string text)
    {
        _gameMenu.SetActive(true);
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
