using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private GameObject cellObject;
    [SerializeField]
    private int amountOfRows;
    [SerializeField]
    private int amountOfColumns;
    [SerializeField]
    private Transform grid;

    private List<int> surroundingElementsCells;
    List<int> tempList;

    GameObject[,] cells;
    int[,] resourceNodes;
    int amountOfResourceNodes;

    private
    // Start is called before the first frame update
    void Start()
    {
        amountOfResourceNodes = Random.Range(5, 15);
        resourceNodes = new int[amountOfResourceNodes, 2];
        cells = new GameObject[amountOfRows, amountOfColumns];



        //tempList = new List<int>();
        //surroundingElementsCells = new List<int>();
        for (int i = 0; i < amountOfResourceNodes; i++)
        {
            resourceNodes[i, 0] = Random.Range(0, amountOfRows);
            resourceNodes[i, 1] = Random.Range(0, amountOfColumns);
        }

        //tempList.Sort();

        //foreach (int item in tempList)
        //{
        //    Debug.Log(item);
        //}
        //int count = 0;
        //int countTwo = 0;


        //surroundingElements();
        //Debug.Log(tempList[0]);
        //Debug.Log(surroundingElementsCells[0]);
        //surroundingElementsCells.Sort();

        for (int i = 0; i < amountOfRows; i++)
        {
            for (int j = 0; j < amountOfColumns; j++)
            {
                GameObject temp = Instantiate(cellObject, grid);
                cells[i, j] = temp;
                temp.GetComponent<CellController>().row = i;
                temp.GetComponent<CellController>().column = j;

                //count++;
                //Debug.Log(i + " " +j);

            }
        }

        for (int i = 0; i < amountOfResourceNodes; i++)
        {
            cells[resourceNodes[i, 0], resourceNodes[i, 1]].GetComponent<CellController>().changeColor();
            surroundingElements(resourceNodes[i, 0], resourceNodes[i, 1]);


        }



        //Debug.Log(count);

        //for (int i = 0; i < amountOfCells; i++)
        //{
        //    GameObject temp = Instantiate(cellObject, grid);


        //    if (count < tempList.Count)
        //    {
        //        if (i == tempList[count])
        //        {
        //            temp.GetComponent<CellController>().changeColor();
        //            count++;
        //        }
        //    }
        //    if (countTwo < surroundingElementsCells.Count)
        //    {
        //        if (i == surroundingElementsCells[countTwo])
        //        {
        //            temp.GetComponent<CellController>().changeColorRed();
        //            countTwo++;
        //        }
        //    }

        //}

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void surroundingElements(int row, int column)
    {
        //inner circle

        Check(row - 1, column - 1, resourceAmount.HALF);
        Check(row - 1, column, resourceAmount.HALF);
        Check(row - 1, column + 1, resourceAmount.HALF);
        Check(row, column - 1, resourceAmount.HALF);
        Check(row, column + 1, resourceAmount.HALF);
        Check(row + 1, column - 1, resourceAmount.HALF);
        Check(row + 1, column, resourceAmount.HALF);
        Check(row + 1, column + 1, resourceAmount.HALF);
        //outer circle
        Check(row - 2, column - 2, resourceAmount.Quarter);
        Check(row - 2, column -1, resourceAmount.Quarter);
        Check(row - 2, column, resourceAmount.Quarter);
        Check(row - 2, column + 1, resourceAmount.Quarter);
        Check(row - 2, column + 2, resourceAmount.Quarter);
        Check(row - 1, column - 2, resourceAmount.Quarter);
        Check(row - 1, column + 2, resourceAmount.Quarter);
        Check(row, column - 2, resourceAmount.Quarter);
        Check(row, column + 2, resourceAmount.Quarter);
        Check(row + 1, column - 2, resourceAmount.Quarter);
        Check(row + 1, column + 2, resourceAmount.Quarter);
        Check(row + 2, column - 2, resourceAmount.Quarter);
        Check(row + 2, column - 1, resourceAmount.Quarter);
        Check(row + 2, column, resourceAmount.Quarter);
        Check(row + 2, column + 1, resourceAmount.Quarter);
        Check(row + 2, column + 2, resourceAmount.Quarter);

        //cells[row - 1, column - 1].GetComponent<CellController>().changeColorRed();
        //cells[row - 1, column].GetComponent<CellController>().changeColorRed();
        //cells[row - 1, column + 1].GetComponent<CellController>().changeColorRed();

        //cells[row, column - 1].GetComponent<CellController>().changeColorRed();
        //cells[row, column + 1].GetComponent<CellController>().changeColorRed();

        //cells[row + 1, column - 1].GetComponent<CellController>().changeColorRed();
        //cells[row + 1, column].GetComponent<CellController>().changeColorRed();
        //cells[row + 1, column + 1].GetComponent<CellController>().changeColorRed();

        


        //surroundingElementsCells.Add(tempList[0] - 31);
        //surroundingElementsCells.Add(tempList[0] - 32);
        //surroundingElementsCells.Add(tempList[0] - 33);
        //surroundingElementsCells.Add(tempList[0] - 1);
        //surroundingElementsCells.Add(tempList[0] + 1);
        //surroundingElementsCells.Add(tempList[0] + 31);
        //surroundingElementsCells.Add(tempList[0] + 32);
        //surroundingElementsCells.Add(tempList[0] + 33);
        //surroundingElementsCells.Add(tempList[0] - 66);
        //surroundingElementsCells.Add(tempList[0] - 65);
        //surroundingElementsCells.Add(tempList[0] - 64);
        //surroundingElementsCells.Add(tempList[0] - 63);
        //surroundingElementsCells.Add(tempList[0] - 62);
        //surroundingElementsCells.Add(tempList[0] - 34);
        //surroundingElementsCells.Add(tempList[0] - 30);
        //surroundingElementsCells.Add(tempList[0] - 2);
        //surroundingElementsCells.Add(tempList[0] + 66);
        //surroundingElementsCells.Add(tempList[0] + 65);
        //surroundingElementsCells.Add(tempList[0] + 64);
        //surroundingElementsCells.Add(tempList[0] + 63);
        //surroundingElementsCells.Add(tempList[0] + 62);
        //surroundingElementsCells.Add(tempList[0] + 34);
        //surroundingElementsCells.Add(tempList[0] + 30);
        //surroundingElementsCells.Add(tempList[0] + 2);
    }

    public void Check(int row, int column, resourceAmount amount)
    {
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
            case resourceAmount.HALF:
                cells[row, column].GetComponent<CellController>().changeColorRed();
                break;
            case resourceAmount.Quarter:
                cells[row, column].GetComponent<CellController>().changeColorYellow();
                break;
            case resourceAmount.Scan:
                cells[row, column].GetComponent<CellController>().changeColorBlue();
                break;
            case resourceAmount.Excavate:
                cells[row, column].GetComponent<CellController>().DegradedTileResource(true);
                break;
            case resourceAmount.Degrade:
                cells[row, column].GetComponent<CellController>().DegradedTileResource(false);
                break;
            default:
                break;
        }

        //Debug.Log(row + " " + column);


        //switch (where)
        //{
        //    case checkCellPlacement.ABOVE:


        //        break;
        //    case checkCellPlacement.RIGHT:
        //        break;
        //    case checkCellPlacement.LEFT:
        //        break;
        //    case checkCellPlacement.BELOW:
        //        break;
        //    default:
        //        break;
        //}


    }

    public void scanElements(int row, int column)
    {
        //inner circle
        Check(row, column, resourceAmount.Scan);

        Check(row - 1, column - 1, resourceAmount.Scan);
        Check(row - 1, column, resourceAmount.Scan);
        Check(row - 1, column + 1, resourceAmount.Scan);
        Check(row, column - 1, resourceAmount.Scan);
        Check(row, column + 1, resourceAmount.Scan);
        Check(row + 1, column - 1, resourceAmount.Scan);
        Check(row + 1, column, resourceAmount.Scan);
        Check(row + 1, column + 1, resourceAmount.Scan);
    }

    public void excavateResource(int row, int column)
    {
        Check(row, column, resourceAmount.Excavate);

        Check(row - 1, column - 1, resourceAmount.Degrade);
        Check(row - 1, column, resourceAmount.Degrade);
        Check(row - 1, column + 1, resourceAmount.Degrade);
        Check(row, column - 1, resourceAmount.Degrade);
        Check(row, column + 1, resourceAmount.Degrade);
        Check(row + 1, column - 1, resourceAmount.Degrade);
        Check(row + 1, column, resourceAmount.Degrade);
        Check(row + 1, column + 1, resourceAmount.Degrade);

        Check(row - 2, column - 2, resourceAmount.Degrade);
        Check(row - 2, column - 1, resourceAmount.Degrade);
        Check(row - 2, column, resourceAmount.Degrade);
        Check(row - 2, column + 1, resourceAmount.Degrade);
        Check(row - 2, column + 2, resourceAmount.Degrade);
        Check(row - 1, column - 2, resourceAmount.Degrade);
        Check(row - 1, column + 2, resourceAmount.Degrade);
        Check(row, column - 2, resourceAmount.Degrade);
        Check(row, column + 2, resourceAmount.Degrade);
        Check(row + 1, column - 2, resourceAmount.Degrade);
        Check(row + 1, column + 2, resourceAmount.Degrade);
        Check(row + 2, column - 2, resourceAmount.Degrade);
        Check(row + 2, column - 1, resourceAmount.Degrade);
        Check(row + 2, column, resourceAmount.Degrade);
        Check(row + 2, column + 1, resourceAmount.Degrade);
        Check(row + 2, column + 2, resourceAmount.Degrade);
    }

    public void gameOverShowAllTiles()
    {
        for (int i = 0; i < amountOfRows; i++)
        {
            for (int j = 0; j < amountOfColumns; j++)
            {
                cells[i,j].GetComponent<CellController>().changeColorBlue();

            }
        }
    }

    public enum resourceAmount
    {
        HALF,
        Quarter,
        Scan,
        Excavate,
        Degrade
    }



}
