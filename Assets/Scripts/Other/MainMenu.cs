using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void LoadLevel(int idLevel)
    {
        Application.LoadLevel(idLevel);
    }
}
