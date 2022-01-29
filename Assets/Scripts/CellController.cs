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
    private GridController gridController;
    void Start()
    {
        gridController = GameObject.Find("Grid").GetComponent<GridController>();
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
        //Update game board for scan
        if (gameController.scanMode && gameController.amountOfScans > 0)
        {
            gridController.scanElements(row, column);
            gameController.setAmountOfScans(-1);
        }
        //Update game board for excavation
        if (!gameController.scanMode && gameController.amountOfExcavations > 0)
        {
            gridController.excavateResource(row, column);
            gameController.setAmountOfExcavations(-1);
            //check if mini game is finished
            if(gameController.amountOfExcavations == 0)
            {
                gridController.gameOverShowAllTiles();
            }
        }
    }
    public void DegradedTileResource(bool isCollected)
    {
        //update game score if tile was collected
        if (isCollected)
        {
            gameController.setAmountOfPoints(resourceAmount);
        }
        //decrease tile's resource amount
        resourceAmount = resourceAmount / 2;
        //make tile empty
        if(resourceAmount < 250)
        {
            resourceAmount = 0;
        }
        //if tile was scanned update color
        if (isScanned)
        {
            scanTileAndUpdateColor();
        }        
    }
}
