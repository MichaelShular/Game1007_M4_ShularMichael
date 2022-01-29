using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    public bool scanMode;
    public int amountOfScans;
    public int amountOfExcavations;
    public int amountOfPoints;
    public Button scanButton;
    public Button exavationButton;
    public TextMeshProUGUI numberOfScansGUI;
    public TextMeshProUGUI numberOfExcavationsGUI;
    public TextMeshProUGUI amountOfOreCollectedGUI;
    public TextMeshProUGUI informationGUI;


    // Start is called before the first frame update
    void Start()
    {
        scanMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Closing Application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void setAmountOfPoints(int amount)
    {
        amountOfPoints += amount;
        amountOfOreCollectedGUI.text = "Amount Of Ore Collected: " + amountOfPoints.ToString();
    }

    public void setAmountOfScans(int amount)
    {
        amountOfScans += amount;
        
        numberOfScansGUI.text = amountOfScans.ToString();
    }

    public void setAmountOfExcavations(int amount)
    {
        amountOfExcavations += amount;
        if (amountOfExcavations <= 0)
        {
            informationGUI.text = "Game over";
        }
        numberOfExcavationsGUI.text = amountOfExcavations.ToString(); 
        
    }
    public void ScanButton()
    {
        scanButton.interactable = false;
        exavationButton.interactable = true;
        scanMode = !scanMode;
    }
    public void ExcavationButton()
    {
        scanButton.interactable = true;
        exavationButton.interactable = false;
        scanMode = !scanMode;
    }
}
