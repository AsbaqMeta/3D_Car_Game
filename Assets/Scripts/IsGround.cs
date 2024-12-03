using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class IsGround : MonoBehaviour
{
    air_time _airTime;
    public bool Ground = false;
    GameObject canvas;
    public ParticleSystem ps;
    public GameObject tozlar;
    private float startSize = 2f, startSpeed = 2.2f, emissionRate = 300, startLifeTime = 0.5f;
    public int maxParticles = 10000;
    public float donus;
    public Color32 level1 = new Color32(255, 255, 255, 255), level2 = new Color32(88, 54, 12, 255), level3 = new Color32(159, 154, 137, 255), level4 = new Color32(159, 154, 137, 255), level5 = new Color32(159, 154, 137, 255);
    public Material kar_material, camur_material, normal_material;
    int sahne_no;
    public bool battle = false, Player = false;
    public static bool havada = false;
    public float _wheelPosition;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        ps = GetComponent<ParticleSystem>();
        if (transform.GetSiblingIndex() == 0)
            tozlar = GameObject.Find("toz1");
        if (transform.GetSiblingIndex() == 1)
            tozlar = GameObject.Find("toz2");
        if (transform.GetSiblingIndex() == 2)
            tozlar = GameObject.Find("toz3");
        if (transform.GetSiblingIndex() == 3)
            tozlar = GameObject.Find("toz4");

        transform.GetComponent<AudioSource>().enabled = true;
        sahne_no = SceneManager.GetActiveScene().buildIndex;
        if (PlayerPrefs.GetInt("Oyun_modu") == 2)
        {
            battle = true;
        }
        if (transform.parent.parent.GetChild(0).tag == "Player")
        {
            Player = true;
            _wheelPosition = transform.position.z;
        }
    }
    /* private void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, _wheelPosition);
    }
 */
    public AudioClip[] clip;
    void OnCollisionEnter()
    {


        havada = false;


        if (Player)
        {
            Ground = true;
            transform.GetComponent<AudioSource>().Play();
            transform.GetComponent<AudioSource>().volume = 1;
        }
    }
    void OnCollisionExit()
    {

        havada = true;

        if (Player)
        {

            {
                if (transform.GetComponent<AudioSource>().isPlaying)
                    transform.GetComponent<AudioSource>().volume = 0;
            }

            tozlar.transform.GetComponent<ParticleSystem>().startSpeed = 0f;
            tozlar.transform.GetComponent<ParticleSystem>().emissionRate = 0f;
            tozlar.transform.GetComponent<ParticleSystem>().startLifetime = 0f;

            Ground = false;
        }
    }
    public bool deger = false;
    public Transform meshh;
    void LateUpdate()
    {
        if (Player)
        {
            tozlar.transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z);//  transform.position;// new Vector3 (ContactPoint.x, ContactPoint.y, ContactPoint.z);

            donus = GetComponent<Rigidbody>().angularVelocity.magnitude / 1.7f;
            if (air_time.carAir == false && Time.timeScale > 0.5)
            {
                tozlar.gameObject.SetActive(true);

                if (gameObject.GetComponent<Rigidbody>().velocity.x < 5.5f)
                {
                    //tozlar.transform.GetComponent<ParticleSystem> ().startSpeed = Mathf.Lerp (tozlar.transform.GetComponent<ParticleSystem> ().startSpeed, donus * startSpeed * 0.11f, Time.deltaTime * 5);
                    tozlar.transform.GetComponent<ParticleSystem>().maxParticles = maxParticles;
                    tozlar.transform.GetComponent<ParticleSystem>().startSize = Mathf.Lerp(tozlar.transform.GetComponent<ParticleSystem>().startSize, donus * startSize * 0.041f, Time.deltaTime * 10);
                    tozlar.transform.GetComponent<ParticleSystem>().emissionRate = Mathf.Lerp(tozlar.transform.GetComponent<ParticleSystem>().emissionRate, donus * emissionRate * 0.003f, Time.deltaTime * 10);
                    tozlar.transform.GetComponent<ParticleSystem>().startLifetime = startLifeTime;


                    if (sahne_no == 1)
                    {
                        tozlar.transform.GetComponent<ParticleSystem>().startColor = level1;
                    }

                    if (sahne_no == 2)
                    {
                        tozlar.transform.GetComponent<ParticleSystem>().startColor = level2;
                    }

                    if (sahne_no == 3)
                    {
                        tozlar.transform.GetComponent<ParticleSystem>().startColor = level3;
                    }

                    if (sahne_no == 4)
                    {
                        tozlar.transform.GetComponent<ParticleSystem>().startColor = level4;
                    }

                    if (sahne_no == 5)
                    {
                        tozlar.transform.GetComponent<ParticleSystem>().startColor = level5;
                    }
                }
                else
                {
                    tozlar.transform.GetComponent<ParticleSystem>().startSpeed = 1.5f;
                    tozlar.transform.GetComponent<ParticleSystem>().emissionRate = 40f;
                    tozlar.transform.GetComponent<ParticleSystem>().startLifetime = 2f;

                }
            }
            else
            {
                tozlar.gameObject.SetActive(false);
                tozlar.transform.GetComponent<ParticleSystem>().startSize = Mathf.Lerp(tozlar.transform.GetComponent<ParticleSystem>().startSize, 0, Time.smoothDeltaTime);
                tozlar.transform.GetComponent<ParticleSystem>().emissionRate = Mathf.Lerp(tozlar.transform.GetComponent<ParticleSystem>().emissionRate, 0, Time.smoothDeltaTime);
                tozlar.transform.GetComponent<ParticleSystem>().startLifetime = startLifeTime;

            }


        }

    }
}
