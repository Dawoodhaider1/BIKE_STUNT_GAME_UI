using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Manager : MonoBehaviour
{
    public void Bike_Selection()
    {
        Application.LoadLevel("Bike_Selection");
    }

    public void Exit_Game()
    {
        Application.Quit();
        Debug.Log("Exit from game !");
    }

    public void Main_Menu()
    {
        Application.LoadLevel("Main_Menu");
    }

    public void GamePlay_Scene()
    {
        Application.LoadLevel("BikeStunt_Levels");
    }
}
