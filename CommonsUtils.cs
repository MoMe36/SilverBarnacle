using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lateral; 

namespace Lateral{





    public class BadGuysUtils : MonoBehaviour
    {

        public static Vector2 RandomDirection(float max_angle)
        {
            float radian_angle = (max_angle*3.14f)/(180f*2f); 
            float random_angle = Random.Range(-radian_angle, radian_angle); 

            return new Vector2(Mathf.Cos(random_angle), Mathf.Sin(random_angle)); 
        }



}


    public class Globals : MonoBehaviour
    {

        public static Dictionary <string, Hitbox> FillHitboxes(List <Hitbox> boxes)
        {
            Dictionary <string, Hitbox> dict = new Dictionary<string, Hitbox>(); 
            for(int i = 0; i<boxes.Count; i++)
            {
                dict.Add(boxes[i].Name, boxes[i]); 
            }
            return dict;
        }


        public static void FillAllBoxes(Hitbox [] boxes, out Dictionary <string, Hitbox> hit_dict, out Dictionary <string, Hitbox> hurt_dict)
        {

            List <Hitbox> hit = new List <Hitbox>();  
            List <Hitbox> hurt = new List <Hitbox>();  

            foreach(Hitbox box in boxes)
            {
                if(box.Type == Hitbox.BoxType.hit)
                    hit.Add(box); 
                else
                    hurt.Add(box); 
            }

            hit_dict = FillHitboxes(hit); 
            hurt_dict = FillHitboxes(hurt); 

        }

        public static void RotateTowardsFlat(Transform character_transform, Vector3 position, float rotation_speed)
        {
            Vector3 direction = Vector3.ProjectOnPlane(position - character_transform.position, Vector3.up); 
            Quaternion rotation = Quaternion.FromToRotation(character_transform.forward, direction); 

            character_transform.rotation = Quaternion.Lerp(character_transform.rotation, rotation*character_transform.rotation, rotation_speed*Time.deltaTime); 
        }


        public static bool SmallerAngle(Vector3 v1, Vector3 v2, float limit)
        {
            float angle =  Vector3.Angle(v1, v2); 
            return angle < limit; 
        }


        public static Transform [] CleanArray(Transform [] targets)
        {
            List<Transform> cleaned = new List<Transform>(); 
            foreach(Transform t in targets)
            {
                if(t != null)
                    cleaned.Add(t); 
            }

            return cleaned.ToArray(); 
        }
    }


[System.Serializable]
    public struct HitData
    {
        public string HitboxName;
        public float ImpulsionStrength;  
        public Vector3 ImpulsionDirection; 
        public float HitForce; 
        public float ActivationTime; 

    }


}