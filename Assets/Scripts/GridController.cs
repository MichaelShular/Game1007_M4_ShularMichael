using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private GameObject cellObject;
    [SerializeField]
    private int amountOfCells;
    [SerializeField]
    private Transform grid;

    private List<int> surroundingElementsCells;
    List<int> tempList;

    private
    // Start is called before the first frame update
    void Start()
    {
        int a = Random.Range(4, 10);

        tempList = new List<int>();
        surroundingElementsCells = new List<int>();
        for (int i = 0; i < a; i++)
        {
            tempList.Add(Random.Range(0, 1023));
        }

        tempList.Sort();

        //foreach (int item in tempList)
        //{
        //    Debug.Log(item);
        //}
        int count = 0;
        int countTwo = 0;

        
        surroundingElements();
        Debug.Log(tempList[0]);
        Debug.Log(surroundingElementsCells[0]);
        surroundingElementsCells.Sort();
        for (int i = 0; i < amountOfCells; i++)
        {
            GameObject temp = Instantiate(cellObject, grid);

            if (count < tempList.Count)
            {
                if (i == tempList[count])
                {
                    temp.GetComponent<CellController>().changeColor();
                    count++;
                }
            }
            if (countTwo < surroundingElementsCells.Count)
            {
                if (i == surroundingElementsCells[countTwo])
                {
                    temp.GetComponent<CellController>().changeColorRed();
                    countTwo++;
                }
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void surroundingElements()
    {
        surroundingElementsCells.Add(tempList[0] - 31);
        surroundingElementsCells.Add(tempList[0] - 32);
        surroundingElementsCells.Add(tempList[0] - 33);
        surroundingElementsCells.Add(tempList[0] - 1);
        surroundingElementsCells.Add(tempList[0] + 1);
        surroundingElementsCells.Add(tempList[0] + 31);
        surroundingElementsCells.Add(tempList[0] + 32);
        surroundingElementsCells.Add(tempList[0] + 33);
    }

}
