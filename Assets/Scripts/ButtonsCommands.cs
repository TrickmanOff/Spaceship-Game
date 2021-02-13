using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsCommands : MonoBehaviour
{
    public void start_game()
    {
        SceneManager.LoadScene(1);
    }

    public void quit_game()
    {
        Application.Quit();
    }
}
