using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MatchItemStates
{
    Falling,
    SettingPosition,
    Stopped,
    Dragged
}

public class MatchItemMovementController : MonoBehaviour
{
    public float _speed;
    private Vector3 _direction;
    private float _YStoppingPosition;
    public float _YStoppingPositionMax;
    public Transform check;
    public MatchItemStates _currentState;
    public bool itemBeingDragged;
    public Vector3 nextPosition;
    public Vector3 ReallastLocalPosition;

    public Vector3 lastPosition;

    public GameObject otherMatch;
    public bool VerticalMovement;
    public bool HorizontalMovment;

    public GameObject currentGridSlot;

    public bool dirSelected;
    public bool swapped;

    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("MatchThreeMiniGame");
        _direction = Vector3.down;
        VerticalMovement = HorizontalMovment = dirSelected = swapped = false;
        //checkBelow();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HorizontalMovment = true;
        }

        switch (_currentState)
        {
            case MatchItemStates.Falling:
                if (transform.localPosition.y <= _YStoppingPosition)
                {
                    _currentState = MatchItemStates.SettingPosition;
                    break;
                }
                Movement();
                break;
            case MatchItemStates.SettingPosition:
                transform.localPosition = new Vector3(transform.localPosition.x, _YStoppingPosition, 0);
                _currentState = MatchItemStates.Stopped;
                break;
            case MatchItemStates.Stopped:
                break;
            case MatchItemStates.Dragged:
                //isDragged();
                break;
            default:
                break;
        }


    }

    private void Movement()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void setYStoppingPosition(float number)
    {
        _YStoppingPosition = number;

    }
    //public void checkBelow()
    //{
    //    Debug.Log("3f");
    //    if (_currentState != MatchItemStates.Stopped) return;
    //    Debug.Log("ff");
    //    RaycastHit2D hit = Physics2D.Raycast(check.position, Vector2.down, 100.0f);
    //    if (hit.collider == null)
    //    {
    //        Debug.Log("aa");
    //    }
    //}

    private void isDragged()
    {
        dirSelected = true;
        if (dirSelected)
        {
            if (HorizontalMovment)
            {
                transform.position = new Vector3(lastPosition.x, Input.mousePosition.y, 0);
            }
            else
            {
                transform.position = new Vector3(Input.mousePosition.x, lastPosition.y, 0);
            }

            return;
        }



        //if (Vector3.Distance(lastLocalPosition, transform.localPosition) > 2)
        //{
        //    if(Vector3.Angle(lastLocalPosition, transform.localPosition) > 45 && Vector3.Angle(lastLocalPosition, transform.localPosition) < 135 || Vector3.Angle(lastLocalPosition, transform.localPosition) > 225 && Vector3.Angle(lastLocalPosition, transform.localPosition) < 315)
        //    {
        //        
        //    }
        //    else
        //    {
        //        transform.position = new Vector3(lastPosition.x, Input.mousePosition.y, 0);

        //    }
        //    return;
        //}
        //used to move item with mouse press
    }

    public void itemDragged()
    {
        if (!GetComponent<MatchItemColor>()._isWall)
        {
            itemBeingDragged = true;
            _currentState = MatchItemStates.Dragged;
            gameController.GetComponent<MatchThreeGameController>().addToSwapList(this.gameObject);
        }


    }
    public void itemDropped()
    {
        _currentState = MatchItemStates.Stopped;
        itemBeingDragged = HorizontalMovment = VerticalMovement = dirSelected = swapped = false;
        transform.localPosition = nextPosition;
        //used to move item with mouse press

    }

}
