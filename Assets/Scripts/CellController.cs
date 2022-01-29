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
    private GameController gameController;
    void Start()
    {
        gameController = GameObject.Find("MiniGameCanvas").GetComponent<GameController>();
        isScanned = false;
    }
    public void setResourceAmount(int amount)
    {
        resourceAmount = amount;
    }
    public void scanTileAndUpdateColor()
    {
        isScanned = true;
        //change tile color
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
    }
    

    public void clickOnCell()
    {
        if (gameController.scanMode && gameController.amountOfScans > 0)
        {
            GameObject.Find("Grid").GetComponent<GridController>().scanElements(row, column);
            gameController.setAmountOfScans(-1);
        }
        
        if(!gameController.scanMode && gameController.amountOfExcavations > 0)
        { 
            GameObject.Find("Grid").GetComponent<GridController>().excavateResource(row, column);
            gameController.setAmountOfExcavations(-1);

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
            gameController.setAmountOfPoints(resourceAmount);
        }

        resourceAmount = resourceAmount / 2;
        if(resourceAmount < 250)
        {
            resourceAmount = 0;
        }
        if (isScanned)
        {
            scanTileAndUpdateColor();
        }        
    }

}
