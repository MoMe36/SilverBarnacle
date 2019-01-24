using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lateral; 

namespace Lateral
{
public class Inputs : MonoBehaviour {

    public float x,y,camX, camY; 
    public bool Dash; 
    public bool ChangeState; 
    public bool Jump; 
    public bool Hit; 
    public bool HeavyHit; 
    public bool Dodge; 
    public bool Shoot; 

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {

        ProcessJS(); 
        
    }

    void ProcessJS()
    {
        x = Input.GetAxis("Horizontal"); 
        y = Input.GetAxis("Vertical"); 

        camX = Input.GetAxis("HorCam");
        camY = Input.GetAxis("VerCam"); 

        ChangeState = Input.GetAxis("L2") > 0.5f; 
        Dash = Input.GetButtonDown("BButton"); 
        Jump = Input.GetButtonDown("AButton"); 
        // Hit = Input.GetButtonDown("XButton"); 
        HeavyHit = Input.GetButtonDown("YButton"); 
        Dodge = Input.GetAxis("R2") > 0.5f; 
        Shoot = Input.GetButtonDown("XButton"); 

    }

    public Vector2 GetDirection()
    {
        Vector2 v = new Vector2(x,y); 

        return v.normalized; 
    }

    public Vector2 GetCamDirection()
    {
        Vector2 v = new Vector2(camX,camY); 
        return v.normalized; 
    }
}

}