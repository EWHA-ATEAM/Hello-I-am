using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneController : MonoBehaviour
{
    public void goToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void goToMain()
    {
        // 선택된 동물의 인덱스를 받아옴
        GameObject animal = EventSystem.current.currentSelectedGameObject;
        AppManager.instance.animal_index = animal.transform.GetSiblingIndex();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void goToStart()
    {
        int _visited = AppManager.instance.getVisited();
        if (_visited == 0)
        {
            AppManager.instance.saveVisited(1);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }
}
