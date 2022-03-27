using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSlotController : MonoBehaviour
{
    public bool isFilled;
    public GameObject currentGameObject;
    public int letPassCount;

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
        if (collision.CompareTag("Match") )
        {
            collision.GetComponent<MatchItemMovementController>().setYStoppingPosition(this.transform.localPosition.y);
            collision.GetComponent<MatchItemMovementController>().nextPosition = this.transform.localPosition;
            collision.GetComponent<MatchItemMovementController>().ReallastLocalPosition = this.transform.localPosition;
            collision.GetComponent<MatchItemMovementController>().currentGridSlot = this.gameObject;

            collision.GetComponent<MatchItemMovementController>().lastPosition = collision.gameObject.transform.position;
            currentGameObject = collision.gameObject;
            //isFilled = true;
            return;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        isFilled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isFilled = false;
    }

}
