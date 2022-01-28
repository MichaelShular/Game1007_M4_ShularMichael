using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    private int resourceAmount;
    public int row;
    public int column;
    public bool isScanned;
    // Start is called before the first frame update
    void Start()
    {
        isScanned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColor()
    {
        //this.GetComponent<Image>().color = Color.green;
        resourceAmount = 1000;
    }
    public void changeColorRed()
    {
        //this.GetComponent<Image>().color = Color.red;
        resourceAmount = 500;

    }

    public void changeColorYellow()
    {
        //this.GetComponent<Image>().color = Color.yellow;
        resourceAmount = 250;
    }

    public void changeColorBlue()
    {
        isScanned = true;
        switch (resourceAmount)
        {
            case 0:
                this.GetComponent<Image>().color = Color.black;
                break;
            case 250:
                this.GetComponent<Image>().color = Color.yellow;
                break;
            case 500:
                this.GetComponent<Image>().color = Color.red;
                break;
            case 1000:
                this.GetComponent<Image>().color = Color.green;
                break;
            default:
                break;
        }

        //this.GetComponent<Image>().color = Color.blue;
        //resourceAmount = 250;
    }
    public void setResourceAmount(int amount)
    {
        resourceAmount = amount;
    }

    public void clickOnCell()
    {
        bool temp = GameObject.Find("MiniGameCanvas").GetComponent<GameController>().scanMode;
        int amountOfScansLeft = GameObject.Find("MiniGameCanvas").GetComponent<GameController>().amountOfScans;
        int amountOfExcavatesLeft = GameObject.Find("MiniGameCanvas").GetComponent<GameController>().amountOfExcavations;

        if (temp && amountOfScansLeft > 0)
        {
            GameObject.Find("Grid").GetComponent<GridController>().scanElements(row, column);
            GameObject.Find("MiniGameCanvas").GetComponent<GameController>().setAmountOfScans(-1);
        }
        
        if(!temp && amountOfExcavatesLeft > 0)
        { 
            GameObject.Find("Grid").GetComponent<GridController>().excavateResource(row, column);
            GameObject.Find("MiniGameCanvas").GetComponent<GameController>().setAmountOfExcavations(-1);

            if(GameObject.Find("MiniGameCanvas").GetComponent<GameController>().amountOfExcavations == 0)
            {
                GameObject.Find("Grid").GetComponent<GridController>().gameOverShowAllTiles();
            }

        }
    }

    public void DegradedTileResource(bool isCollected)
    {
        if (isCollected)
        {
            GameObject.Find("MiniGameCanvas").GetComponent<GameController>().setAmountOfPoints(resourceAmount);
        }

        resourceAmount = resourceAmount / 2;
        if(resourceAmount < 250)
        {
            resourceAmount = 0;
        }
        if (isScanned)
        {
            changeColorBlue();
        }        
    }

}
