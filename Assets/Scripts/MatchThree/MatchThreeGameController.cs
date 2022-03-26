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
    public int[] createAmount;


    // Start is called before the first frame update
    void Start()
    {
        cells = new GameObject[_gridSize, _gridSize];
        matchingList = new List<GameObject>();
        swapItems = new List<GameObject>();
        createAmount = new int[_gridSize];

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
                temp.GetComponent<MatchItemMovementController>()._currentState = MatchItemStates.Stopped;
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
                            matchingList[k].tag = "MatchDestroy";
                            //matchingList[k].GetComponent<MatchItemMovementController>().currentGridSlot.GetComponent<GridSlotController>().currentGameObject = null;

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
                            matchingList[k].tag = "MatchDestroy";

                            //matchingList[k].GetComponent<MatchItemMovementController>().currentGridSlot.GetComponent<GridSlotController>().currentGameObject = null;
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
                    matchingList[k].tag = "MatchDestroy";

                    //matchingList[k].GetComponent<MatchItemMovementController>().currentGridSlot.GetComponent<GridSlotController>().currentGameObject = null;

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
                //cells[i, j].GetComponent<GridSlotController>().isFilled = false;
                if (countColorHor == cells[i, j].GetComponent<GridSlotController>().currentGameObject.GetComponent<MatchItemColor>()._currentColor)
                {
                    count++;


                    if (count >= 2)
                    {
                        for (int k = 0; k < matchingList.Count; k++)
                        {
                            matchingList[k].transform.localScale = Vector3.one * 0.2f;
                            matchingList[k].tag = "MatchDestroy";

                            //matchingList[k].GetComponent<MatchItemMovementController>().currentGridSlot.GetComponent<GridSlotController>().currentGameObject = null;

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
                            matchingList[k].tag = "MatchDestroy";

                            //matchingList[k].GetComponent<MatchItemMovementController>().currentGridSlot.GetComponent<GridSlotController>().currentGameObject = null;

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
                    matchingList[k].tag = "MatchDestroy";

                    //matchingList[k].GetComponent<MatchItemMovementController>().currentGridSlot.GetComponent<GridSlotController>().currentGameObject = null;

                    //Destroy(matchingList[k].gameObject);
                }
                //cells[i, j].GetComponent<MatchItemColor>()._image.color = Color.black;
                //Debug.Log("Hit");
            }
        }

        GameObject[] temp = GameObject.FindGameObjectsWithTag("MatchDestroy");

        for (int i = 0; i < temp.Length; i++)
        {
            temp[i].GetComponent<MatchItemMovementController>().currentGridSlot.GetComponent<GridSlotController>().currentGameObject = null;
            Destroy(temp[i]);
        }


        //for (int i = 0; i < _gridSize; i++)
        //{
        //    for (int j = 0; j < _gridSize; j++)
        //    {
        //        if (cells[i, j].GetComponent<GridSlotController>().currentGameObject == null)
        //        {
        //            //if (i - 1 > 0)
        //            //{
        //            //    //cells[i, j].GetComponent<GridSlotController>().letPassCount = 1 * cells[i -1 , j].GetComponent<GridSlotController>().letPassCount; 
        //            //}
        //            //for (int l = i; l < _gridSize; l++)
        //            //{
        //            //    if (l + 1 < _gridSize)
        //            //    {
        //            //        cells[l + 1, j].GetComponent<GridSlotController>().letPassCount++;
        //            //    }

        //            //}
        //            //for (int l = 1; l < _gridSize; l++)
        //            //{
        //            //    if (l < _gridSize && cells[j , l].GetComponent<GridSlotController>().currentGameObject != null)
        //            //    {
        //            //        cells[ j, l ].GetComponent<GridSlotController>().currentGameObject.GetComponent<MatchItemMovementController>().setYStoppingPosition(cells[i, j].transform.localPosition.y);
        //            //    }

        //            //}


        //            //if (i + 1 < _gridSize && cells[i + 1, j].GetComponent<GridSlotController>().currentGameObject != null)
        //            //{
        //            //    cells[i + 1, j].GetComponent<GridSlotController>().letPassCount = 7;
        //            //    //cells[i + 1, j].GetComponent<GridSlotController>().currentGameObject.GetComponent<MatchItemMovementController>().setYStoppingPosition(-500);
        //            //    cells[i + 1, j].GetComponent<GridSlotController>().currentGameObject.GetComponent<MatchItemMovementController>()._currentState = MatchItemStates.Falling;
        //            //    //cells[i + 1, j].GetComponent<GridSlotController>().currentGameObject = null;
        //            //}

        //        }
        //    }
        //}


    }

    public void place()
    {
        int letPassCount = 0;
        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {
                if (cells[j, i].GetComponent<GridSlotController>().isFilled == false)
                {
                    letPassCount++;
                }
            }
            
            createAmount[i] = letPassCount;
            letPassCount = 0;
            Debug.Log(createAmount[i]);
            //letPassCount--;
            //for (int l = 0; l < _gridSize; l++)
            //{
            //    cells[(_gridSize - 1) - l, i].GetComponent<GridSlotController>().letPassCount = letPassCount;
            //    letPassCount--;
            //    if (letPassCount < 0)
            //    {
            //        letPassCount = 0;
            //    }
            //}
        }

        float boardSize = _gridSize * 20 + (_gridSize - 1 * 2);
        float bottomLimit = 0 - boardSize / 2;

        int count = 0;
        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < createAmount[i]; j++)
            {

                GameObject temp = Instantiate(_MatchThreeObject, this.transform);
                //cells[i, j] = temp;
                temp.transform.localPosition = new Vector3(bottomLimit + 22 * i, 100 + 22 * j, 0);
                temp.GetComponent<MatchItemMovementController>().setYStoppingPosition(-500);
                temp.GetComponent<MatchItemMovementController>()._currentState = MatchItemStates.Stopped;
                temp.GetComponent<MatchItemColor>().RandomColor();
                temp.GetComponent<MatchItemColor>().num = count;
                count++;

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
        StartCoroutine(waitFall());


    }

    public void addToSwapList(GameObject matchItem)
    {
        swapItems.Add(matchItem);
    }

    IEnumerator waitFall()
    {
        yield return new WaitForSeconds(8.0f);
        place();
    }
}
