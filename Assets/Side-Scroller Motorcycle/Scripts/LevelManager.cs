using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject FinishPanel;
    public GameObject[] levelPanels;

    private void Start()
    {
        Debug.Log("Current Level number: " + MainManager.Instance.Level_Index);
        levelPanels[MainManager.Instance.Level_Index].SetActive(true);
    }

    public void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void NextLevel()
    {
        Motorcycle_Controller.isControllable = true;
        MainManager.Instance.Level_Index++;

        if (MainManager.Instance.Level_Index >= levelPanels.Length)
        {
            MainManager.Instance.Level_Index = 0;
        }

        for (int i = 0; i < levelPanels.Length; i++)
        {
            if (i == MainManager.Instance.Level_Index)
            {
                Application.LoadLevel(Application.loadedLevel);
                FinishPanel.SetActive(false);
            }
            else
            {
                levelPanels[MainManager.Instance.Level_Index].SetActive(false);
            }
        }
    }
}
