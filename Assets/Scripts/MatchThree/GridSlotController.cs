using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSlotController : MonoBehaviour
{
    public bool isFilled;

    // Start is called before the first frame update
    void Start()
    {
        isFilled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Match") && !isFilled)
        {
            collision.GetComponent<MatchItemMovementController>().setYStoppingPosition(this.transform.localPosition.y);
            isFilled = true;   
        }
    }

}
