using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Selection : MonoBehaviour
{
    public GameObject[] Levels;

    private int Level_Number = -1;

    // Start is called before the first frame update
    void Start()
    {
        // Add a listener to each item that sets the selectedItem value when clicked
        for (int i = 0; i < Levels.Length; i++)
        {
            int levelNumber = i;
            Levels[i].GetComponent<Button>().onClick.AddListener(() => SetSelectedItem(levelNumber));
        }
    }

    // This function sets the selectedItem value to the number of the item that was clicked
    void SetSelectedItem(int itemNumber)
    {
        Level_Number = itemNumber;
        MainManager.Instance.Selected_Level = Level_Number;
        Debug.Log("Selected Level is: " + Level_Number);
    }
}
