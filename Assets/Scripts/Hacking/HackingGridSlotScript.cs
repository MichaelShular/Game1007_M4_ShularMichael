using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackingGridSlotScript : MonoBehaviour
{
    public int row;
    public int column;
    public int checkingNumber;

    public string code;

    HackingMiniGameController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindObjectOfType<HackingMiniGameController>();
    }

    public void OnSlotClicked()
    {
        controller._currentHackCheck++;

        checkIfSuccess();
        if (controller._currentHackCheck % 2 == 0)
        {
            Debug.Log("asd");
           
         controller._LastNumberToCheck = column;
        }
        else
        {
            Debug.Log("aege");
            controller._LastNumberToCheck = row;
        }
        if (controller._currentHackCheck == controller._HardCombinationUI.Count - 1)
        {
            bool temp = false;
            foreach (bool item in controller._combinationSuccess)
            {
                if (item)
                {
                    temp = true;
                }


            }
            controller.OpenResultPanel(temp);
        }

    }

    public void checkIfSuccess()
    {
        if (controller._LastNumberToCheck == -1)
        {
            controller._LastNumberToCheck = row;  
            
        }
        if (controller._currentHackCheck % 2 == 0)
        {
            checkingNumber = row;
            Debug.Log("sad");
        }
        else
        {
            checkingNumber = column;
            Debug.Log("a");

        }
        Debug.Log(checkingNumber);
        Debug.Log(controller._currentHackCheck);

        if (controller._combinationSuccess[2] && code == controller._HardCombination[controller._currentHackCheck] && checkingNumber == controller._LastNumberToCheck)
        {
            controller._HardCombinationUI[controller._currentHackCheck].GetComponentInChildren<Image>().enabled = true;
        }
        else
        {
            controller._HardCombinationUI[controller._currentHackCheck].GetComponentInChildren<Image>().enabled = true;
            controller._HardCombinationUI[controller._currentHackCheck].GetComponentInChildren<Image>().color = Color.red;
            controller._combinationSuccess[2] = false;
        }

        if (controller._currentHackCheck >= controller._MediumCombination.Count) return;

        if (controller._combinationSuccess[1] && code == controller._MediumCombination[controller._currentHackCheck] && checkingNumber == controller._LastNumberToCheck)
        {
            controller._MediumCombinationUI[controller._currentHackCheck].GetComponentInChildren<Image>().enabled = true;
        }
        else
        {
            controller._MediumCombinationUI[controller._currentHackCheck].GetComponentInChildren<Image>().enabled = true;
            controller._MediumCombinationUI[controller._currentHackCheck].GetComponentInChildren<Image>().color = Color.red;
            controller._combinationSuccess[1] = false;
        }

        if (controller._currentHackCheck >= controller._EasyCombination.Count) return;

        if (controller._combinationSuccess[0] && code == controller._EasyCombination[controller._currentHackCheck] && checkingNumber == controller._LastNumberToCheck)
        {
            controller._EasyCombinationUI[controller._currentHackCheck].GetComponentInChildren<Image>().enabled = true;
        }
        else
        {
            controller._EasyCombinationUI[controller._currentHackCheck].GetComponentInChildren<Image>().enabled = true;
            controller._EasyCombinationUI[controller._currentHackCheck].GetComponentInChildren<Image>().color = Color.red;
            controller._combinationSuccess[0] = false;
        }

        
    }
}
