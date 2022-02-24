using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridController : MonoBehaviour
{
    [SerializeField] private Transform grid;
    [SerializeField] private GameObject cellTile;
    [SerializeField] private int amountOfRows;
    [SerializeField] private int amountOfColumns;
    private GameObject[,] cells;
    private int[,] resourceNodesPositions;
    private int amountOfResourceNodes;
    //Number patterns used to affect the surrounding tiles  
    private int[,] innerCircleResourceNodePositions = { { 1, 1 }, { -1, 1 }, { 1, 0 }, { 0, 1 } };
    private int[,] outerCircleResourceNodePositions = { { 2, 2 }, { 2, 1 }, { 2, 0 }, { -2, 1 }, { -2, 2 }, { -1, -2 }, { -1, 2 }, { 0, 2 } };
    // Start is called before the first frame update
    void Start()
    {
        //Randomizing amount of full resource tiles
        amountOfResourceNodes = Random.Range(8, 15);
        //initializing array sizes
        resourceNodesPositions = new int[amountOfResourceNodes, 2];
        cells = new GameObject[amountOfRows, amountOfColumns];

        //Randomizing full resources tile positions
        for (int i = 0; i < amountOfResourceNodes; i++)
        {
            resourceNodesPositions[i, 0] = Random.Range(0, amountOfRows);
            resourceNodesPositions[i, 1] = Random.Range(0, amountOfColumns);
        }
        //Instantiate grid cells and saving position into cells array
        for (int i = 0; i < amountOfRows; i++)
        {
            for (int j = 0; j < amountOfColumns; j++)
            {
                GameObject temp = Instantiate(cellTile, grid);
                cells[i, j] = temp;
                temp.GetComponent<CellController>().row = i;
                temp.GetComponent<CellController>().column = j;
            }
        }
        //Passing information to cells for which tiles are full resource then change surrounding to appropriate amount of resource 
        for (int i = 0; i < amountOfResourceNodes; i++)
        {
            cells[resourceNodesPositions[i, 0], resourceNodesPositions[i, 1]].GetComponent<CellController>().setResourceAmount(1000);
            surroundingCells(resourceNodesPositions[i, 0], resourceNodesPositions[i, 1]);
        }
    }
    public void surroundingCells(int row, int column)
    {
        tileSelector(row, column, innerCircleResourceNodePositions, tileUpdateType.HALF);
        tileSelector(row, column, outerCircleResourceNodePositions, tileUpdateType.Quarter);
    }

    public void updateTile(int row, int column, tileUpdateType amount)
    {
        //check to see if row/column are within the minimum and maximum amount of the grid 
        if (row < 0)
            return;
        if (column < 0)
            return;
        if (row >= amountOfRows)
            return;
        if (column >= amountOfColumns)
            return;
        switch (amount)
        {
            case tileUpdateType.HALF:
                cells[row, column].GetComponent<CellController>().setResourceAmount(500);
                break;
            case tileUpdateType.Quarter:
                cells[row, column].GetComponent<CellController>().setResourceAmount(250);
                break;
            case tileUpdateType.Scan:
                cells[row, column].GetComponent<CellController>().scanTileAndUpdateColor();
                break;
            case tileUpdateType.Excavate:
                cells[row, column].GetComponent<CellController>().DegradedTileResource(true);
                break;
            case tileUpdateType.Degrade:
                cells[row, column].GetComponent<CellController>().DegradedTileResource(false);
                break;
            default:
                break;
        }
    }
    public void scanElements(int row, int column)
    {
        updateTile(row, column, tileUpdateType.Scan);
        tileSelector(row, column, innerCircleResourceNodePositions, tileUpdateType.Scan);
    }
    public void excavateResource(int row, int column)
    {
        updateTile(row, column, tileUpdateType.Excavate);
        tileSelector(row, column, innerCircleResourceNodePositions, tileUpdateType.Degrade);
        tileSelector(row, column, outerCircleResourceNodePositions, tileUpdateType.Degrade);
    }
    
    //Used select tiles base of patterned number give from 2-d array
    private void tileSelector(int row, int column, int[,] twoDimentionArray, tileUpdateType type)
    {
        for (int i = 0; i < twoDimentionArray.GetLength(0); i++)
        {
            updateTile(row - twoDimentionArray[i, 0], column - twoDimentionArray[i, 1], type);
            updateTile(row - twoDimentionArray[i, 0] * -1, column - twoDimentionArray[i, 1] * -1, type);
        }
    }
    public void gameOverShowAllTiles()
    {
        for (int i = 0; i < amountOfRows; i++)
        {
            for (int j = 0; j < amountOfColumns; j++)
            {
                cells[i, j].GetComponent<CellController>().scanTileAndUpdateColor();
            }
        }
    }
    public enum tileUpdateType
    {
        HALF,
        Quarter,
        Scan,
        Excavate,
        Degrade
    }
}
