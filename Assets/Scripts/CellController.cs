using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    private float resourceAmount;
    public int row;
    public int column;
    // Start is called before the first frame update
    void Start()
    {
        
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
        this.GetComponent<Image>().color = Color.blue;
        //resourceAmount = 250;
    }
    public void setResourceAmount(float amount)
    {
        resourceAmount = amount;
    }

    public void clickOnCell()
    {
        bool temp = GameObject.Find("MiniGameCanvas").GetComponent<GameController>().scanMode;

        if (temp)
        {
            GameObject.Find("Grid").GetComponent<GridController>().scanElements(row, column);
        }
        else
        {

        }
    }
}
