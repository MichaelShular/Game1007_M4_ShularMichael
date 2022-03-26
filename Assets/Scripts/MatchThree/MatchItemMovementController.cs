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

    // Start is called before the first frame update
    void Start()
    {
        _direction = Vector3.down;
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

    


}
