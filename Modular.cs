using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lateral; 

namespace Lateral{


[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(Animator))]
public class Modular : MonoBehaviour {

    public enum States {idle, run, jump, shoot};
    public enum SubStates {idle, fire}; 

    public States current_state = States.idle; 
    public SubStates current_sub_state = SubStates.idle; 


    Vector2 player_direction; 
    Vector2 player_cam_direction; 

    Inputs inputs; 
    Move move; 
    Fight fight; 
    Rigidbody rb; 
    Animator anim; 

    // Make the game playable: 
    // - Add Projectile creation 
    // - Add projectile behaviour and hitboxes
    

    // Use this for initialization
    void Start () {

        Initialization(); 
        
    }
    
    // Update is called once per frame
    void Update () {

        RelativeToMove(); 
        RelativeToFight(); 
        
    }

    void RelativeToMove()
    {
        player_direction = inputs.GetDirection(); 
        player_cam_direction = inputs.GetCamDirection(); 

        move.PlayerMove(player_direction); 

        if(inputs.Jump)
            move.Jump(); 

    }

    void RelativeToFight()
    {
        if(inputs.Shoot)
            fight.Shoot(); 

        // if(inputs.Hit)
        // {
        //     if(current_state == States.fight)
        //         fight.Combo();
        //     else
        //         fight.Hit();  
        // }

    }

    public bool IsIdle()
    {
        return current_state == States.idle; 
    }

    public bool IsRunning()
    {
        return current_state == States.run; 
    }

    public bool IsJumping()
    {
        return current_state == States.jump; 
    }

    public void InformHit(string info, bool state)
    {

    }

    public void Inform(string info, bool state)
    {
        if(info == "Idle")
        {
            if(state)
            {
                current_state = States.idle; 
                move.EnterIdle(); 
            }
        }

        else if(info == "Run")
        {
            if(state)
            {
                current_state = States.run; 
                move.EnterRun(); 
            }
        }

        else if(info == "Jump")
        {
            if(state)
            {
                current_state = States.jump; 
                move.EnterJump();     
            }
        }

        else if(info =="JumpIdle")
        {
            if(state)
            {
                current_state = States.jump; 
                move.EnterJumpIdle(); 
            }
        }

        else if(info == "Shoot")
        {
            if(state)
            {
                current_state = States.shoot; 
            }
        }

         else if(info == "AirShoot")
        {
            if(state)
            {
                current_state = States.shoot; 
                move.EnterAirShoot(); 
            }
        }

    }


    public void HitInform(HitData data, bool state)
    {
     // fight.Activation(data, state); 
     // if(state)
     // {
     //     move.HitImpulsion(data); 
     // }
     return; 
    }

    // public void WeaponInform(string state)
    // {
    //  fight.GetWeapon(state); 
    // }

    // public void ImpactInform(HitData data, Vector3 direction)
    // {
    //     // bool dodge = DodgeInform(); 

    //     // if(dodge)
    //     // {
    //     //  fight.Dodge(); 
    //     // }
    //     // else
    //     // {
    //         fight.Impacted(); // triggers impact animation 
    //         move.ChangeVelocity(direction*data.HitForce);  
    //     // }
    // }


    // // This function is used to shortcut the hitbox activation in the case of a projectile using particles 

    // public void ProjectileImpactInform()
    // {
    //  bool dodge = DodgeInform(); 
    //  if(dodge)
    //  {
    //      fight.Dodge(); 
    //  }
    //  else
    //  {
    //      fight.Impacted(); 
    //  }
    // }

    // public bool Ask(string info)
    // {
    //  if(info == "Jump")
    //  {
    //      return (current_state != States.jump);
    //  }

    //  else
    //      return false; 
    // }

    // public void ComputeDashDirection()
    // {
    //  move.ComputeDirectionAndAdjustAnim(player_direction); 
    // }

    void Initialization()
    {
        inputs = GetComponent<Inputs>(); 
        move = GetComponent<Move>(); 
        rb = GetComponent<Rigidbody>(); 
        anim = GetComponent<Animator>(); 
        fight = GetComponent<Fight>(); 
    }
}

}