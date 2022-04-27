using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftAttack : MonoBehaviour
{
    [SerializeField] float shiftDistance;
    [SerializeField] int shiftDamage;
    [SerializeField] Transform camTF;
    bool jumpInputQued; //For when input is collected in update to be used in update
    [SerializeField] int shiftCoolDown;
    public int framesSinceShift;
    void FixedUpdate()
    {
        framesSinceShift+=1;
        if(Input.GetKey(KeyCode.E) && framesSinceShift>=0)
        {
            framesSinceShift = -shiftCoolDown;
            RaycastHit hit;
            if(Physics.Raycast(transform.position, camTF.forward, out hit, shiftDistance))
            {
                HitPointPool targetHPP= hit.collider.gameObject.GetComponent<HitPointPool>();
                if(targetHPP!=null)
                {
                    targetHPP.hitPoints-=shiftDamage;
                }
            }
            transform.position += camTF.forward*shiftDistance;
        }
    }
}
