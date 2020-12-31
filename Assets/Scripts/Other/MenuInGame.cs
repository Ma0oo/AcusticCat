using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _gameMenu.SetActive(!_gameMenu.activeSelf);
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
