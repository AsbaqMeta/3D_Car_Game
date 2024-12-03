using UnityEngine;
using System.Collections;
 
public class Enemy_Bullet_Script : MonoBehaviour
{   
    public GameObject projectileParticle;    
    public GameObject[] trailParticles;
    [HideInInspector]
    public Vector3 impactNormal; //Used to rotate impactparticle.    
 
    private bool hasCollided = false;
    public bool SOUND;

    private void OnEnable()
    {        
        hasCollided = false;
        gameObject.GetComponent<Rigidbody>().WakeUp();
        if (SOUND)
        {
            projectileParticle.GetComponent<AudioSource>().Play();
        }
        Invoke("Hide_Bullet", 3f);
    }

    private void OnDisable()
    {        
        gameObject.GetComponent<Rigidbody>().Sleep();
        hasCollided = false;
        CancelInvoke();
    }

    void Hide_Bullet()
    {        
        gameObject.SetActive(false);
    }

    void Start()
    {        

        projectileParticle = Instantiate(projectileParticle, transform.position, transform.rotation) as GameObject;
        projectileParticle.transform.parent = transform;             
    }
 
    void OnCollisionEnter(Collision hit)
    {
        if (!hasCollided)
        {
            hasCollided = true;            

            if (hit.collider.tag == "Player")
            {                
                //hit.collider.SendMessageUpwards("Damage", SendMessageOptions.DontRequireReceiver);
                Enemy_Damage_info[2] = hit.contacts[0].point.y/2;
                hit.collider.SendMessage("DamageProcess", Enemy_Damage_info, SendMessageOptions.DontRequireReceiver);
                Hide_Bullet();
            }
            

        }
    }

    public float[] Enemy_Damage_info = new float[7]; // 0 : Damage // 1: Critical Chance // 2: Collision Point
}