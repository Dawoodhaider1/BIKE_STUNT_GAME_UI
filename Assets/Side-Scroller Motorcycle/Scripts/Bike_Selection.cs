using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike_Selection : MonoBehaviour
{
    public GameObject[] bikes;
    private int currentBike = 0;

    void Start()
    {
        ShowBike();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentBike--;
            if (currentBike < 0)
            {
                currentBike = bikes.Length - 1;
            }
            ShowBike();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentBike++;
            if (currentBike == bikes.Length)
            {
                currentBike = 0;
            }
            ShowBike();
        }
    }

    public void Left_Bike()
    {
        currentBike--;
        if (currentBike < 0)
        {
            currentBike = bikes.Length - 1;
        }
        ShowBike();
    }

    public void Right_Bike()
    {
        currentBike++;
        if (currentBike == bikes.Length)
        {
            currentBike = 0;
        }
        ShowBike();
    }

    void ShowBike()
    {
        for (int i = 0; i < bikes.Length; i++)
        {
            if (i == currentBike)
            {
                bikes[i].SetActive(true);
            }
            else
            {
                bikes[i].SetActive(false);
            }
        }
    }
}
