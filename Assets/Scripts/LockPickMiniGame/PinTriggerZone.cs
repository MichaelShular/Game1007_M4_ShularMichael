using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinTriggerZone : MonoBehaviour
{
   public void setTiggerZoneHeight(float height)
    {
        transform.localPosition = new Vector3(transform.localPosition.x, height, transform.localPosition.z);
    }
}
