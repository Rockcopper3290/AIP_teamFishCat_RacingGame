using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dropdown_Menu : MonoBehaviour
{
    public Node_Gen_Create Node_Gen_Create;
    public TMPro.TMP_Dropdown current_Menu;


    public void Car_amountSelecter()
    {
        switch (current_Menu.value)
        {
            case (0):
                Node_Gen_Create.numberOfFishCats = 1;
                Debug.Log("message - 1");
                break;
            case (1):
                Node_Gen_Create.numberOfFishCats = 2;
                Debug.Log("message - 2");
                break;
            case (2):
                Node_Gen_Create.numberOfFishCats = 3;
                Debug.Log("message - 3");
                break;
            case (3):
                Node_Gen_Create.numberOfFishCats = 4;
                Debug.Log("message - 4");
                break;
            case (4):
                Node_Gen_Create.numberOfFishCats = 5;
                Debug.Log("message - 5");
                break;
            case (5):
                Node_Gen_Create.numberOfFishCats = 6;
                Debug.Log("message - 6");
                break;
            case (6):
                Node_Gen_Create.numberOfFishCats = 7;
                Debug.Log("message - 7");
                break;
            case (7):
                Node_Gen_Create.numberOfFishCats = 8;
                Debug.Log("message - 8");
                break;
            case (8):
                Node_Gen_Create.numberOfFishCats = 9;
                Debug.Log("message - 9");
                break;

            default:
                break;
        }
    }

    public void Oil_Spill_amountSelecter()
    {
        switch (current_Menu.value)
        {
            case (0):
                Node_Gen_Create.numberOfOilSpills = 1;
                Debug.Log("message - 1");
                break;
            case (1):
                Node_Gen_Create.numberOfOilSpills = 2;
                Debug.Log("message - 2");
                break;
            case (2):
                Node_Gen_Create.numberOfOilSpills = 3;
                Debug.Log("message - 3");
                break;
            case (3):
                Node_Gen_Create.numberOfOilSpills = 4;
                Debug.Log("message - 4");
                break;
            case (4):
                Node_Gen_Create.numberOfOilSpills = 5;
                Debug.Log("message - 5");
                break;
            case (5):
                Node_Gen_Create.numberOfOilSpills = 6;
                Debug.Log("message - 6");
                break;
            case (6):
                Node_Gen_Create.numberOfOilSpills = 7;
                Debug.Log("message - 7");
                break;
            case (7):
                Node_Gen_Create.numberOfOilSpills = 8;
                Debug.Log("message - 8");
                break;
            case (8):
                Node_Gen_Create.numberOfOilSpills = 9;
                Debug.Log("message - 9");
                break;

            default:
                break;
        }
    }

    public void Cat_Food_amountSelecter()
    {
        switch (current_Menu.value)
        {
            case (0):
                Node_Gen_Create.numberOfCatFood = 1;
                Debug.Log("message - 1");
                break;
            case (1):
                Node_Gen_Create.numberOfCatFood = 2;
                Debug.Log("message - 2");
                break;
            case (2):
                Node_Gen_Create.numberOfCatFood = 3;
                Debug.Log("message - 3");
                break;
            case (3):
                Node_Gen_Create.numberOfCatFood = 4;
                Debug.Log("message - 4");
                break;
            case (4):
                Node_Gen_Create.numberOfCatFood = 5;
                Debug.Log("message - 5");
                break;
            case (5):
                Node_Gen_Create.numberOfCatFood = 6;
                Debug.Log("message - 6");
                break;
            case (6):
                Node_Gen_Create.numberOfCatFood = 7;
                Debug.Log("message - 7");
                break;
            case (7):
                Node_Gen_Create.numberOfCatFood = 8;
                Debug.Log("message - 8");
                break;
            case (8):
                Node_Gen_Create.numberOfCatFood = 9;
                Debug.Log("message - 9");
                break;

            default:
                break;
        }
    }

    public void Tacocat_amountSelecter()
    {
        switch (current_Menu.value)
        {
            case (0):
                Node_Gen_Create.numberOfTacocat = 1;
                Debug.Log("message - 1");
                break;
            case (1):
                Node_Gen_Create.numberOfTacocat = 2;
                Debug.Log("message - 2");
                break;
            case (2):
                Node_Gen_Create.numberOfTacocat = 3;
                Debug.Log("message - 3");
                break;
            case (3):
                Node_Gen_Create.numberOfTacocat = 4;
                Debug.Log("message - 4");
                break;
            case (4):
                Node_Gen_Create.numberOfTacocat = 5;
                Debug.Log("message - 5");
                break;
            case (5):
                Node_Gen_Create.numberOfTacocat = 6;
                Debug.Log("message - 6");
                break;
            case (6):
                Node_Gen_Create.numberOfTacocat = 7;
                Debug.Log("message - 7");
                break;
            case (7):
                Node_Gen_Create.numberOfTacocat = 8;
                Debug.Log("message - 8");
                break;
            case (8):
                Node_Gen_Create.numberOfTacocat = 9;
                Debug.Log("message - 9");
                break;

            default:
                break;
        }
    }



}
