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
            collision.GetComponent<MatchItemMovementController>().nextPosition = this.transform.localPosition;
            collision.GetComponent<MatchItemMovementController>().ReallastLocalPosition = this.transform.localPosition;
            collision.GetComponent<MatchItemMovementController>().currentGridSlot = this.gameObject;

            collision.GetComponent<MatchItemMovementController>().lastPosition = collision.gameObject.transform.position;
            currentGameObject = collision.gameObject;
            isFilled = true;
            return;
        }
        //if (collision.CompareTag("Match") && isFilled && collision.GetComponent<MatchItemMovementController>().itemBeingDragged && !collision.GetComponent<MatchItemMovementController>().swapped)
        //{
        //    collision.GetComponent<MatchItemMovementController>().swapped = true;
        //    Vector3 temp = currentGameObject.transform.localPosition;

        //    currentGameObject.transform.localPosition = collision.GetComponent<MatchItemMovementController>().nextPosition;
        //    currentGameObject.GetComponent<MatchItemMovementController>().ReallastLocalPosition = currentGameObject.transform.localPosition;
        //    currentGameObject.GetComponent<MatchItemMovementController>().nextPosition = currentGameObject.transform.localPosition;
            
        //    currentGameObject.GetComponent<MatchItemMovementController>().currentGridSlot = collision.GetComponent<MatchItemMovementController>().currentGridSlot;
        //    currentGameObject.GetComponent<MatchItemMovementController>().lastPosition = currentGameObject.GetComponent<MatchItemMovementController>().currentGridSlot.transform.position;

        //    collision.gameObject.GetComponent<MatchItemMovementController>().nextPosition = transform.localPosition;
        //    collision.gameObject.GetComponent<MatchItemMovementController>().currentGridSlot = this.gameObject;


        //}

    }

}
