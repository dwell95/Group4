using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HitPointPool))]
public class EnemyHPCondition : MonoBehaviour
{
    void FixedUpdate()
    {
        if(GetComponent<HitPointPool>().hitPoints<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
