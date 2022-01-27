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
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountOfCells; i++)
        {
            GameObject temp = Instantiate(cellObject, grid);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
