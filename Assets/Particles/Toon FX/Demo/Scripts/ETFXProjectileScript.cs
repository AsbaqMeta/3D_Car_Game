using UnityEngine;
 
public class ETFXProjectileScript : MonoBehaviour
{
    public GameObject impactParticle;
    public GameObject projectileParticle;
    //public GameObject[] trailParticles;
    [HideInInspector]
    public Vector3 impactNormal; //Used to rotate impactparticle.    
 
    private bool hasCollided = false;
    public bool SniperBullet = false;
    public bool SOUND_is_ON = true;

    private void OnEnable()
    {
        hasCollided = false;
        gameObject.GetComponent<Rigidbody>().WakeUp();        
        if (SOUND_is_ON)
        {
            //projectileParticle.GetComponent<AudioSource>().enabled = true;
            projectileParticle.GetComponent<AudioSource>().Play();
        }
        else
        {
            //projectileParticle.GetComponent<AudioSource>().enabled = false;
        }
        Invoke("Hide_Bullet", 3f);
    }

    private void OnDisable()
    {
        gameObject.GetComponent<Rigidbody>().Sleep();        
        CancelInvoke();
    }

    void Hide_Bullet()
    {
        gameObject.SetActive(false);
    }
    
    void Start()
    {
        projectileParticle = Instantiate(projectileParticle, transform.position, transform.rotation) as GameObject;// Bu obje için objectpool gereksiz çünkü sadece bir kez örneklendirilip sürekli kullanılıyor
        projectileParticle.transform.parent = transform;        
        impactParticle = Instantiate(impactParticle) as GameObject;
        impactParticle.SetActive(false);
    }
 
    void OnCollisionEnter(Collision hit)
    {        
        if (!hasCollided)
        {            
            hasCollided = true;
            bool Target_is_close = false;            
                       
            //if (hit.collider.CompareTag("Enemy"))
            //{
            //    Target_is_close = hit.collider.GetComponent<EnemyAIv4>().Player_is_in_Range();
            //}
            //if (hit.collider.CompareTag("Enemy_Ranged"))
            //{
            //    Target_is_close = hit.collider.GetComponent<EnemyHandGunAI>().Player_is_in_Range();
            //}
            //if (hit.collider.CompareTag("Enemy_Sniper"))
            //{
            //    Target_is_close = hit.collider.GetComponent<EnemySniperAIV2>().Player_is_in_Range();
            //}
            //if (hit.collider.CompareTag("Enemy_RocketMan"))
            //{
            //    Target_is_close = hit.collider.GetComponent<EnemyRocketManAIV2>().Player_is_in_Range();
            //}
            //if (hit.collider.CompareTag("Enemy_FlamerMan"))
            //{
            //    Target_is_close = hit.collider.GetComponent<EnemyFlamerManAIV2>().Player_is_in_Range();
            //}
            //if (hit.collider.CompareTag("Enemy_Scientist"))
            //{
            //    Target_is_close = hit.collider.GetComponent<EnemyScientistAI>().Player_is_in_Range();
            //}
            //if (hit.collider.CompareTag("EnemyBoss"))
            //{
            //    Target_is_close = hit.collider.GetComponent<EnemyBossAI>().Player_is_in_Range();
            //}
            //if (hit.collider.CompareTag("Kukla"))
            //{
            //    Target_is_close = hit.collider.GetComponent<FirstZombie>().Player_is_in_Range();
            //}

            if (SniperBullet) { Target_is_close = SniperBullet; }
            
            
            if (Target_is_close)
            {
                impactParticle.SetActive(true);
                impactParticle.transform.position = transform.position;
                impactParticle.GetComponent<ParticleSystem>().Play(true);
                if (SOUND_is_ON)
                {
                    impactParticle.GetComponent<AudioSource>().enabled = true;
                }                
            }
            
            string Related_Damage_Function = "Enemy_Damage_Process_Bullet";
            if (SniperBullet){ Related_Damage_Function = "Enemy_Damage_Process_SniperBullet"; }
            
            if (hit.collider.tag == "Enemy")
            {
                //hit.collider.SendMessageUpwards("Damage", SendMessageOptions.DontRequireReceiver);
                Enemy_Damage_info[2] = hit.contacts[0].point.y;
                hit.collider.SendMessage(Related_Damage_Function, Enemy_Damage_info, SendMessageOptions.DontRequireReceiver);
            }
            if (hit.collider.tag == "Kukla")
            {
                //hit.collider.SendMessageUpwards("Damage", SendMessageOptions.DontRequireReceiver);
                Enemy_Damage_info[2] = hit.contacts[0].point.y;
                hit.collider.SendMessage(Related_Damage_Function, Enemy_Damage_info, SendMessageOptions.DontRequireReceiver);
            }

            if (hit.collider.tag == "Enemy_Ranged")
            {
                //hit.collider.SendMessageUpwards("Damage", SendMessageOptions.DontRequireReceiver);
                Enemy_Damage_info[2] = hit.contacts[0].point.y;
                hit.collider.SendMessage(Related_Damage_Function, Enemy_Damage_info, SendMessageOptions.DontRequireReceiver);
            }

            if (hit.collider.tag == "Enemy_Sniper")
            {
                //hit.collider.SendMessageUpwards("Damage", SendMessageOptions.DontRequireReceiver);
                Enemy_Damage_info[2] = hit.contacts[0].point.y;
                hit.collider.SendMessage(Related_Damage_Function, Enemy_Damage_info, SendMessageOptions.DontRequireReceiver);
            }

            if (hit.collider.tag == "Enemy_FlamerMan")
            {
                //hit.collider.SendMessageUpwards("Damage", SendMessageOptions.DontRequireReceiver);
                Enemy_Damage_info[2] = hit.contacts[0].point.y;
                hit.collider.SendMessage(Related_Damage_Function, Enemy_Damage_info, SendMessageOptions.DontRequireReceiver);
            }

            if (hit.collider.tag == "Enemy_RocketMan")
            {
                //hit.collider.SendMessageUpwards("Damage", SendMessageOptions.DontRequireReceiver);
                Enemy_Damage_info[2] = hit.contacts[0].point.y;
                hit.collider.SendMessage(Related_Damage_Function, Enemy_Damage_info, SendMessageOptions.DontRequireReceiver);
            }

            if (hit.collider.tag == "Enemy_Scientist")
            {
                //hit.collider.SendMessageUpwards("Damage", SendMessageOptions.DontRequireReceiver);
                Enemy_Damage_info[2] = hit.contacts[0].point.y;
                hit.collider.SendMessage(Related_Damage_Function, Enemy_Damage_info, SendMessageOptions.DontRequireReceiver);
            }
            if (hit.collider.tag == "EnemyBoss")
            {
                //hit.collider.SendMessageUpwards("Damage", SendMessageOptions.DontRequireReceiver);
                Enemy_Damage_info[2] = hit.contacts[0].point.y;
                hit.collider.SendMessage(Related_Damage_Function, Enemy_Damage_info, SendMessageOptions.DontRequireReceiver);
            }


            Hide_Bullet();
        }
    }
    public float[] Enemy_Damage_info = new float[7]; // 0 : Damage // 1: Critical Chance // 2: Collision Point //9: SniperBullet 1/0
        
}