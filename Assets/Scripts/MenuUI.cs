using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]

public class MenuUI : MonoBehaviour {
    
    public void StartNew() 
{
    SceneManager.LoadScene(1);
}

 public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // To if kleinei to paixnidi stin unity, to else se kanoniko build
#endif
    }

    public void BackToMenu()
{
    SceneManager.LoadScene(0);
}

}
