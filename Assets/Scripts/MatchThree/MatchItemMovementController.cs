using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MatchItemStates
{
    Falling,
    SettingPosition,
    Stopped
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
    public Vector3 lastLocalPosition;
    public Vector3 ReallastLocalPosition;

    public Vector3 lastPosition;

    public GameObject otherMatch;
    public bool VerticalMovement;
    public bool HorizontalMovment;

    

    // Start is called before the first frame update
    void Start()
    {
        _direction = Vector3.down;
        VerticalMovement = HorizontalMovment = false;
        //checkBelow();
    }

    // Update is called once per frame
    void Update()
    {

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

    public void itemDragged()
    {
        itemBeingDragged = true;
        //Debug.Log(Vector2.SignedAngle(lastLocalPosition, transform.localPosition));
        if (Vector3.Distance(ReallastLocalPosition, transform.localPosition) > 1)
        {
            if (Mathf.Abs(ReallastLocalPosition.x - transform.localPosition.x) < Mathf.Abs(ReallastLocalPosition.y - transform.localPosition.y))
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
        if (itemBeingDragged)
        {
            

            transform.position = Input.mousePosition; 
            
            
        }
    }
    public void itemDropped()
    {
        itemBeingDragged = false;
        transform.localPosition = lastLocalPosition;
        //used to move item with mouse press
        
    }

}
