using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lateral; 

namespace Lateral
{



public class Hitbox : MonoBehaviour {

    public string Name = "myhitbox"; 

    public enum BoxType {hit, hurt, projectile};
    public BoxType Type = BoxType.hit;
    public GameObject ImpactEffect;  
    public bool Active = false; 

    [Header("Refers to")]
    public Modular PlayerReference; 
    // public NierEnnemyModular EnnemyReference; 


    HitData current_hit_data; 

    void OnTriggerEnter(Collider other)
    {
        if(Type == BoxType.hit)
        {
            CollisionWithHitbox(other);
        }   
        else if(Type == BoxType.projectile)
        {
            // CollisionWithParticle(other); 
        }

    }

    // void CollisionWithParticle(Collider other)
    // {
    //     Hitbox other_hb = other.GetComponent<Hitbox>(); 
    
    //     if(other_hb != null)
    //     {
    //         if(other_hb.Type == Hitbox.BoxType.hurt)
    //         {
    //             Vector3 normalized_direction = (other_hb.gameObject.transform.position - transform.position).normalized; 
    //             current_hit_data = GetComponent<ProjectileBasic>().HitInfo; 
    //             other_hb.Impacted(current_hit_data, normalized_direction); 
    //         }
    //     }
    //     Destroy(transform.root.gameObject); 
    //     CreateEffect(transform.position); 
    // }

    void CollisionWithHitbox(Collider other)
    {
        if(Active)
        {
            Hitbox other_hb = other.GetComponent<Hitbox>(); 
    
            if(other_hb != null)
            {
                if(other_hb.Type == Hitbox.BoxType.hurt)
                {
                    Vector3 normalized_direction = (other_hb.gameObject.transform.position - transform.position).normalized; 
                    other_hb.Impacted(current_hit_data, normalized_direction); 
                    CreateEffect(transform.position); 
                }
            }
        }
    }

    void CreateEffect(Vector3 position)
    {
        GameObject p = Instantiate(ImpactEffect, position, ImpactEffect.transform.rotation) as GameObject; 
    }

    public void Impacted(HitData impact_data, Vector3 direction)
    {
        // if(PlayerReference != null)
        // {
        //     PlayerReference.ImpactInform(impact_data, Vector3.ProjectOnPlane(direction, Vector3.up));
        // }
        // else
        // {
        //     EnnemyReference.ImpactInform(impact_data, direction);
        // }
        // return ; 
    }

    public void SetState(HitData data, bool state)
    {
        if(state)
        {
            current_hit_data = data; 
            Active = true; 
        }
        else
        {
            Active = false; 
        }
    }

    // public void GetReferenced(out NierModular player_ref, out NierEnnemyModular ennemy_ref)
    // {
    //     player_ref = PlayerReference; 
    //     ennemy_ref = EnnemyReference; 
    // }



}

}
