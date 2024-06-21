using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectType : MonoBehaviour
{
   public enum Object
   {
        bomb = 0,
        usualCar = 1,
        coin = 2,
        enviromentObject = 3
   }
    public Object TypeObject;
}
