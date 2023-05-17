using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public GameObject helpWindow;

    public void GameStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameQuit()
    {
        Debug.Log("Ending");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }

    public void HelpWindowOpen()
    {
        if (!helpWindow.activeSelf)
            helpWindow.gameObject.SetActive(true);
    }

    public void HelpWindowClose()
    {
        if(helpWindow.activeSelf) 
        {
            helpWindow.gameObject.SetActive(false);
        }
        
    }

    public void esterEgg()
    {
        if(Random.Range(0, 100) < 10)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
