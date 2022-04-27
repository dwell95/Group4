using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HitPointPool))]
public class UnderWorldHPLoss : MonoBehaviour
{
    void FixedUpdate()
    {
        if(transform.position.y<0)
        {
        GetComponent<HitPointPool>().hitPoints-=1;
        }
    }
}