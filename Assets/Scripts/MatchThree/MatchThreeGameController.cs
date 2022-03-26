using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchThreeGameController : MonoBehaviour
{
    public int _gridSize;
    //public int gridYSize;
    public GameObject _MatchThreeObject;
    public GameObject _slot;

    private GameObject[,] cells;
    private List<GameObject> matchingList;

    public List<GameObject> swapItems;

    // Start is called before the first frame update
    void Start()
    {
        cells = new GameObject[_gridSize, _gridSize];
        matchingList = new List<GameObject>();
        swapItems = new List<GameObject>();
        creatingGameBoard();
        createGrid();
    }

    // Update is called once per frame
    void Update()
    {
        if (swapItems.Count == 2)
        {
            swap();
        }
    }

    private void createGrid()
    {
        float boardSize = _gridSize * 20 + (_gridSize - 1 * 2);
        float bottomLimit = 0 - boardSize / 2;
        int passCount = 0;
        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {

                GameObject temp = Instantiate(_slot, this.transform);
                cells[i, j] = temp;
                temp.transform.localPosition = new Vector3(bottomLimit + 22 * j, -50 + 22 * i, 0);
                temp.GetComponent<GridSlotController>().letPassCount = passCount;
            }
            passCount++;
        }



    }

    private void creatingGameBoard()
    {
        float boardSize = _gridSize * 20 + (_gridSize - 1 * 2);
        float bottomLimit = 0 - boardSize / 2;

        int count = 0;
        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {

                GameObject temp = Instantiate(_MatchThreeObject, this.transform);
                //cells[i, j] = temp;
                temp.transform.localPosition = new Vector3(bottomLimit + 22 * i, 100 + 22 * j, 0);
                temp.GetComponent<MatchItemMovementController>().setYStoppingPosition(-500);
                temp.GetComponent<MatchItemMovementController>()._currentState = MatchItemStates.Falling;
                temp.GetComponent<MatchItemColor>().RandomColor();
                temp.GetComponent<MatchItemColor>().num = count;
                count++;

            }
        }
        //checkBoard();
    }

    private void checkBoard()
    {
        MatchThreeColor countColorHor = MatchThreeColor.None;
        //for (int i = 0; i < _gridSize; i++)
        //{
        //    for (int j = 0; j < _gridSize; j++)
        //    {
        //        cells[i,j] 
        //    }
        //}



        int count = 0;
        for (int i = 0; i < _gridSize; i++)
        {
            countColorHor = MatchThreeColor.None;
            count = 0;
            for (int j = 0; j < _gridSize; j++)
            {
                //Debug.Log(count);

                if (countColorHor == cells[i, j].GetComponent<GridSlotController>().currentGameObject.GetComponent<MatchItemColor>()._currentColor)
                {
                    count++;

                    if (count >= 2)
                    {
                        for (int k = 0; k < matchingList.Count; k++)
                        {
                            matchingList[k].transform.localScale = Vector3.one * 0.2f;
                            //Destroy(matchingList[k].gameObject);
                        }
                        //cells[i, j].GetComponent<MatchItemColor>()._image.color = Color.black;
                        //Debug.Log("Hit");
                    }
                }
                else
                {
                    if (count >= 2)
                    {
                        for (int k = 0; k < matchingList.Count; k++)
                        {
                            matchingList[k].transform.localScale = Vector3.one * 0.2f;
                            //Destroy(matchingList[k].gameObject);
                        }
                    }
                    count = 0;

                    matchingList.Clear();


                }
                countColorHor = cells[i, j].GetComponent<GridSlotController>().currentGameObject.GetComponent<MatchItemColor>()._currentColor;
                matchingList.Add(cells[i, j].GetComponent<GridSlotController>().currentGameObject);
                //Debug.Log(matchingList);

            }
            if (count >= 2)
            {
                for (int k = 0; k < matchingList.Count; k++)
                {
                    matchingList[k].transform.localScale = Vector3.one * 0.2f;
                    //Destroy(matchingList[k].gameObject);
                }
                //cells[i, j].GetComponent<MatchItemColor>()._image.color = Color.black;
                //Debug.Log("Hit");
            }
        }

        for (int j = 0; j < _gridSize; j++)
        {
            countColorHor = MatchThreeColor.None;
            count = 0;
            for (int i = 0; i < _gridSize; i++)
            {

                if (countColorHor == cells[i, j].GetComponent<GridSlotController>().currentGameObject.GetComponent<MatchItemColor>()._currentColor)
                {
                    count++;


                    if (count >= 2)
                    {
                        for (int k = 0; k < matchingList.Count; k++)
                        {
                            matchingList[k].transform.localScale = Vector3.one * 0.2f;
                            //Destroy(matchingList[k].gameObject);
                        }
                        //cells[i, j].GetComponent<MatchItemColor>()._image.color = Color.black;
                        //Debug.Log("Hit");
                    }
                }
                else
                {
                    if (count >= 2)
                    {
                        for (int k = 0; k < matchingList.Count; k++)
                        {
                            matchingList[k].transform.localScale = Vector3.one * 0.2f;
                            //Destroy(matchingList[k].gameObject);
                        }
                    }
                    count = 0;

                    matchingList.Clear();

                }
                countColorHor = cells[i, j].GetComponent<GridSlotController>().currentGameObject.GetComponent<MatchItemColor>()._currentColor;
                matchingList.Add(cells[i, j].GetComponent<GridSlotController>().currentGameObject);
                //Debug.Log(count + " " + countColorHor);

            }
            if (count >= 2)
            {
                for (int k = 0; k < matchingList.Count; k++)
                {
                    matchingList[k].transform.localScale = Vector3.one * 0.2f;
                    //Destroy(matchingList[k].gameObject);
                }
                //cells[i, j].GetComponent<MatchItemColor>()._image.color = Color.black;
                //Debug.Log("Hit");
            }
        }




    }
    private void swap()
    {
        Vector3 temp = swapItems[0].transform.localPosition;
        Vector3 temp2 = swapItems[1].transform.localPosition;

        GameObject tempGridSlot = swapItems[0].GetComponent<MatchItemMovementController>().currentGridSlot;
        GameObject tempGridSlot2 = swapItems[1].GetComponent<MatchItemMovementController>().currentGridSlot;

        swapItems[0].GetComponent<MatchItemMovementController>().currentGridSlot = tempGridSlot2;
        swapItems[1].GetComponent<MatchItemMovementController>().currentGridSlot = tempGridSlot;

        swapItems[0].GetComponent<MatchItemMovementController>().currentGridSlot.GetComponent<GridSlotController>().currentGameObject = swapItems[0].gameObject;
        swapItems[1].GetComponent<MatchItemMovementController>().currentGridSlot.GetComponent<GridSlotController>().currentGameObject = swapItems[1].gameObject;

        swapItems[0].transform.localPosition = temp2;
        swapItems[1].transform.localPosition = temp;
        swapItems.Clear();
        checkBoard();
    }

    public void addToSwapList(GameObject matchItem)
    {
        swapItems.Add(matchItem);
    }
}
