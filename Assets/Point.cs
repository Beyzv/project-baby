using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

   public enum PointType { 
        movePoint,
        attackPoint,
        speedPoint,
    
    };

    public PointType type;

}
