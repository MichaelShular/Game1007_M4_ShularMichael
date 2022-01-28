using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool scanMode;
    public int amountOfScans;
    public int amountOfExcavations;
    public int amountOfPoints;

    // Start is called before the first frame update
    void Start()
    {
        scanMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAmountOfPoints(int amount)
    {
        amountOfPoints += amount;
    }

}
