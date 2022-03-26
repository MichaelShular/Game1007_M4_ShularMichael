using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSlotController : MonoBehaviour
{
    public bool isFilled;
    public GameObject currentGameObject;

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
            collision.GetComponent<MatchItemMovementController>().lastLocalPosition = this.transform.localPosition;
            collision.GetComponent<MatchItemMovementController>().ReallastLocalPosition = this.transform.localPosition;


            collision.GetComponent<MatchItemMovementController>().lastPosition = collision.transform.position;
            currentGameObject = collision.gameObject;
            isFilled = true;
            return;
        }
        if(collision.CompareTag("Match") && isFilled && collision.GetComponent<MatchItemMovementController>().itemBeingDragged)
        {
            currentGameObject.transform.localPosition = collision.GetComponent<MatchItemMovementController>().lastLocalPosition;
            




            collision.GetComponent<MatchItemMovementController>().lastLocalPosition = this.transform.localPosition;
        }

    }

}
