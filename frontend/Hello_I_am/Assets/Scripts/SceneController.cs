using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void goToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void goToMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
