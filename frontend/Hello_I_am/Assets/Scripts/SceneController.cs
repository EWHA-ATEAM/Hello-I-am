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
}
