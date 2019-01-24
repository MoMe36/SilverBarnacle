using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lateral; 

namespace Lateral
{

public class Fight : MonoBehaviour {
 
    // Dictionary <string, Hitbox> hitboxes; 
    // Dictionary <string, Hitbox> hurtboxes;

    Animator anim; 
    Rigidbody rb; 
    Modular mothership;     


    // Use this for initialization
    void Start () {
        Initialization(); 

        // FindTargets(); 
    }
    
    // Update is called once per frame
    void Update () {

        // UpdateTimers(); 

    }

    public void SetTrigger(string s)
    {
        anim.SetTrigger(s); 
    }

    public void Hit()
    {
        SetTrigger("Hit"); 
    }

    public void Shoot()
    {
        SetTrigger("Shoot"); 
    }

    // public void Activation(HitData data, bool state)
    // {
    //     hitboxes[data.HitboxName].SetState(data, state); 
    // }


    public void Dodge()
    {   
        anim.SetTrigger("Dodge"); 
    }

    public void Impacted()
    {
        anim.SetTrigger("Impact"); 
    }

    void Initialization()
    {
        anim = GetComponent<Animator>(); 
        rb = GetComponent<Rigidbody>(); 
        mothership = GetComponent<Modular>(); 

        // GlobalUtils.FillAllBoxes(Hitboxes, out hitboxes, out hurtboxes); 
        // hitboxes = Globals.FillHitboxes(Hitboxes); 
    }

}

}
