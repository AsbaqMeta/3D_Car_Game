using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class truckk_yeni : MonoBehaviour
{

    [Header("Upgrade Value")]
    public float MaxAngularVel;
    public float kuvvet;
    public float dynamicFrictionValue;
    public float benzin_hizi;
    public bool dort_ceker;

    [Header("Other")]
    public GameObject _characterSpine;
    public ConfigurableJoint[] suspansion;
    public Transform[] Wheels;
    public GameObject exhaust;
    public PhysicMaterial physicMaterial;
    [HideInInspector] public bool carUP, carDown;
    [HideInInspector] public GameObject benzin_spawn;
    [HideInInspector] public Vector3 Temp_pos;
    bool once2 = true;
    bool beks = false;
    float temp2 = 0f;
    public float Benzin = 100;
    public GameObject benzin_ses, coin_ses;
    public Transform StartSound;
    public Transform idleSound;
    public Transform MovementSound;
    public GameObject brakeSound;
    public GameObject turboBlowOffSound;
    public Transform MainMesh;
    private const float RPM = 1550;
    [HideInInspector] public bool gas;
    [HideInInspector] public bool fren;
    public static bool finishFren = false;
    [HideInInspector] public bool onceben = true;
    [HideInInspector] public int carID;
    [HideInInspector] public bool carflying, carflying2;
    [HideInInspector] public float botNitrotimer, botnitrotimer2, timer;
    public GameObject breaklight;
    [HideInInspector] public bool gazla = true;
    [HideInInspector] public bool yapay_basladi = false;
    [HideInInspector] public bool gameStart = false;
    bool turboblow;
    void Start()
    {
        timer = 4;
        botnitrotimer2 = 0;
        botNitrotimer = Random.Range(5, 35);
        carflying = true;
        finishFren = false;
        exhaust.transform.GetChild(0).gameObject.SetActive(false);
        exhaust.transform.GetChild(1).gameObject.SetActive(true);
        canvas = GameObject.Find("Canvas");
        benzin_spawn = GameObject.FindGameObjectWithTag("benzin");
        Benzin = 100;
        physicMaterial.dynamicFriction = dynamicFrictionValue;

    }
    [System.Obsolete]
    void FixedUpdate()
    {

       
        if (transform.tag != "yapay")
        {

            Motor();
            for (int i = 0; i < Wheels.Length; i++)
            {
                if (canvas.GetComponent<oyunici>()._4WDClick)
                {
                    Wheels[i].transform.DOScale(1.25f, 1.5f);
                }
                else
                {
                    Wheels[i].transform.DOScale(1, 1.5f);
                }
            }
            if (finishFren)
            {
                for (int i = 0; i < Wheels.Length; i++)
                {
                    Wheels[i].GetComponent<Rigidbody>().maxAngularVelocity = 0.2f;
                }
            }
            if (!finishFren)
            {
                for (int i = 0; i < Wheels.Length; i++)
                {
                    Wheels[i].GetComponent<Rigidbody>().maxAngularVelocity = MaxAngularVel;
                }
            }


        }
        else
        {
            if (canvas.GetComponent<oyunici>().gamePlayPanel.activeSelf && yapay_basladi == false)
            {
                yapay_basladi = true;
            }
            Motor_yapay();
            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i].GetComponent<Rigidbody>().maxAngularVelocity = MaxAngularVel;
            }
        }
    }

    [System.Obsolete]
    void Motor()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.x < -2.5 || gameObject.GetComponent<Rigidbody>().velocity.x > 2.5)
        {
            exhaust.transform.GetChild(1).GetComponentInChildren<ParticleSystem>().startSize = Mathf.Lerp(exhaust.transform.GetChild(1).GetChild(0).GetComponent<ParticleSystem>().startSize, 0, 5 * Time.deltaTime);
        }
        else
        {
            exhaust.transform.GetChild(1).GetComponentInChildren<ParticleSystem>().startSize = Mathf.Lerp(exhaust.transform.GetChild(1).GetChild(0).GetComponent<ParticleSystem>().startSize, 0.25f, 5 * Time.deltaTime);

        }
        if (canvas.GetComponent<oyunici>().olme == false && canvas.GetComponent<oyunici>().isgas == true && canvas.GetComponent<oyunici>().finished==false )
        {
            if (gas || fren)
            {
                Benzin -= benzin_hizi / 100;
            }
            else
            {
                    Benzin -= (benzin_hizi / 2) / 100;

            }
        }
      



        if (!gas && !fren)
        {
            brakeSound.GetComponent<AudioSource>().volume = Mathf.Lerp(brakeSound.GetComponent<AudioSource>().volume, 0f, Time.maximumDeltaTime);
        }


        if (gas)
        {
            if (gameObject.GetComponent<Rigidbody>().velocity.x < 3.5)
            {
                exhaust.transform.GetChild(1).GetComponentInChildren<ParticleSystem>().startColor = new Color(1, 8f, 1, 0.5f);

            }
            else
            {
                exhaust.transform.GetChild(1).GetComponentInChildren<ParticleSystem>().startColor = new Color(1, 8f, 1, 0.3f);
            }
        }
        else
        {
            exhaust.transform.GetChild(1).GetChild(0).GetComponent<ParticleSystem>().startColor = new Color(1, 8f, 1, 0.4f);
        }


        if (gas)
        {
            if (MovementSound.GetComponent<AudioSource>().pitch > 1.35f)
            {
                turboblow = true;
            }
            if (gameObject.GetComponent<Rigidbody>().velocity.x < 1.8f && !air_time.carAir)
            {
                brakeSound.GetComponent<AudioSource>().volume = Mathf.Lerp(brakeSound.GetComponent<AudioSource>().volume, 0.3f, Time.smoothDeltaTime);
            }
            else
            {
                brakeSound.GetComponent<AudioSource>().volume = Mathf.Lerp(brakeSound.GetComponent<AudioSource>().volume, 0f, Time.maximumDeltaTime);
            }
            if (!dort_ceker)
            {

                if (gameObject.GetComponent<Rigidbody>().velocity.x < 2.5f && dynamicFrictionValue < 1f)
                {
                    MainMesh.GetComponent<Rigidbody>().AddTorque(transform.forward * Time.deltaTime * (kuvvet + 350), ForceMode.Acceleration);

                }
                else
                {
                    MainMesh.GetComponent<Rigidbody>().AddTorque(transform.forward * Time.deltaTime * kuvvet, ForceMode.Acceleration);
                }

            }
            else
            {

                MainMesh.GetComponent<Rigidbody>().AddTorque(transform.forward * Time.deltaTime * ((kuvvet * 2) / 3), ForceMode.Acceleration);
            }

            if (air_time.carAir == false)
            {
                MovementSound.GetComponent<AudioSource>().pitch = Mathf.Lerp(MovementSound.GetComponent<AudioSource>().pitch, (-1 * Wheels[1].GetComponent<Rigidbody>().angularVelocity.z / 25), Time.smoothDeltaTime);
                MovementSound.GetComponent<AudioSource>().volume = Mathf.Lerp(MovementSound.GetComponent<AudioSource>().volume, 1.3f, Time.smoothDeltaTime);
            }
            if (air_time.carAir == true)
            {
                MovementSound.GetComponent<AudioSource>().pitch = Mathf.Lerp(MovementSound.GetComponent<AudioSource>().pitch, (-1 * Wheels[1].GetComponent<Rigidbody>().angularVelocity.z / 25), Time.smoothDeltaTime);
                MovementSound.GetComponent<AudioSource>().volume = Mathf.Lerp(MovementSound.GetComponent<AudioSource>().volume, 1f, Time.smoothDeltaTime);
            }

            if (dort_ceker)
            {
                for (int i = 0; i < Wheels.Length; i++)
                {
                    Wheels[i].GetComponent<Rigidbody>().AddTorque(-RPM * Wheels[i].transform.forward * 32f * Time.deltaTime, ForceMode.Acceleration);
                }
            }
            else
            {
                for (int i = 0; i < Wheels.Length - 2; i++)
                {
                    Wheels[i].GetComponent<Rigidbody>().AddTorque(-RPM * Wheels[i].transform.forward * 32f * Time.deltaTime, ForceMode.Acceleration);
                }

            }
        }
        else
        {
            if (turboblow)
            {
                turboblow = false;
                turboBlowOffSound.GetComponent<AudioSource>().Play();
            }

            //idleSound.GetComponent<AudioSource>().volume = Mathf.Lerp(idleSound.GetComponent<AudioSource>().volume, 0.7f, Time.smoothDeltaTime);
            MovementSound.GetComponent<AudioSource>().pitch = Mathf.Lerp(MovementSound.GetComponent<AudioSource>().pitch, 1f, Time.maximumDeltaTime / 4);
            MovementSound.GetComponent<AudioSource>().volume = Mathf.Lerp(MovementSound.GetComponent<AudioSource>().volume, 0.5f, Time.smoothDeltaTime);
        }

        if (fren)
        {
            if (!dort_ceker)
            {

                MainMesh.GetComponent<Rigidbody>().AddTorque(transform.forward * Time.deltaTime * -kuvvet, ForceMode.Acceleration);
            }
            else
            {
                MainMesh.GetComponent<Rigidbody>().AddTorque(transform.forward * Time.deltaTime * ((-kuvvet * 2) / 3), ForceMode.Acceleration);
            }

            breaklight.SetActive(true);

            if (gameObject.GetComponent<Rigidbody>().velocity.x < -2.5)
            {
                exhaust.transform.GetChild(1).GetComponentInChildren<ParticleSystem>().startColor = new Color(1, 8f, 1, 0.5f);
            }
            else
            {
                exhaust.transform.GetChild(1).GetComponentInChildren<ParticleSystem>().startColor = new Color(1, 8f, 1, 0.3f);
            }

            if (transform.GetChild(0).GetComponent<Rigidbody>().velocity.x <= 1f)
            {
                MovementSound.GetComponent<AudioSource>().pitch = Mathf.Lerp(MovementSound.GetComponent<AudioSource>().pitch, (Wheels[1].GetComponent<Rigidbody>().angularVelocity.z / 20), Time.smoothDeltaTime);
                MovementSound.GetComponent<AudioSource>().volume = Mathf.Lerp(MovementSound.GetComponent<AudioSource>().volume, 1.3f, Time.smoothDeltaTime);
                if (dort_ceker)
                {
                    for (int i = 0; i < Wheels.Length; i++)
                    {
                        Wheels[i].GetComponent<Rigidbody>().AddTorque(RPM * 50 * Wheels[i].transform.forward * 32f * Time.deltaTime, ForceMode.Force);
                    }
                }
                else
                {
                    for (int i = 0; i < Wheels.Length - 2; i++)
                    {
                        Wheels[i].GetComponent<Rigidbody>().AddTorque(RPM * 50 * Wheels[i].transform.forward * 32f * Time.deltaTime, ForceMode.Force);
                    }
                }
                if (gameObject.GetComponent<Rigidbody>().velocity.x > -1.8f && !air_time.carAir)
                {
                    brakeSound.GetComponent<AudioSource>().volume = Mathf.Lerp(brakeSound.GetComponent<AudioSource>().volume, 0.3f, Time.smoothDeltaTime);
                }
                else
                {
                    brakeSound.GetComponent<AudioSource>().volume = Mathf.Lerp(brakeSound.GetComponent<AudioSource>().volume, 0f, Time.maximumDeltaTime);
                }
            }
            else
            {
                for (int i = 0; i < Wheels.Length; i++)
                {
                    Wheels[i].GetComponent<Rigidbody>().AddTorque(RPM * 10 * Wheels[i].transform.forward * 32f * Time.smoothDeltaTime, ForceMode.Force);
                    if (!air_time.carAir)
                    {
                        brakeSound.GetComponent<AudioSource>().volume = Mathf.Lerp(brakeSound.GetComponent<AudioSource>().volume, 0.3f, Time.smoothDeltaTime);
                    }
                    else
                    {
                        brakeSound.GetComponent<AudioSource>().volume = Mathf.Lerp(brakeSound.GetComponent<AudioSource>().volume, 0f, Time.maximumDeltaTime);
                    }
                }
            }
        }
        else
        {
            breaklight.SetActive(false);
            brakeSound.GetComponent<AudioSource>().volume = Mathf.Lerp(brakeSound.GetComponent<AudioSource>().volume, 0f, Time.maximumDeltaTime);
        }
    }

    void Motor_yapay()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.x < -2.5 || gameObject.GetComponent<Rigidbody>().velocity.x > 2.5)
        {
            exhaust.transform.GetChild(1).GetComponentInChildren<ParticleSystem>().startSize = Mathf.Lerp(exhaust.transform.GetChild(1).GetChild(0).GetComponent<ParticleSystem>().startSize, 0, 5 * Time.deltaTime);
        }
        else
        {
            exhaust.transform.GetChild(1).GetComponentInChildren<ParticleSystem>().startSize = Mathf.Lerp(exhaust.transform.GetChild(1).GetChild(0).GetComponent<ParticleSystem>().startSize, 0.25f, 5 * Time.deltaTime);

        }
        MainMesh.GetComponent<Rigidbody>().AddTorque(transform.forward * Time.deltaTime * kuvvet, ForceMode.Acceleration);
        if ((MainMesh.eulerAngles.z > 60 && gameObject.GetComponent<Rigidbody>().velocity.x > 9) || (MainMesh.eulerAngles.z < 200 && MainMesh.eulerAngles.z > 140))
        {
            MainMesh.GetComponent<Rigidbody>().AddTorque(transform.forward * Time.deltaTime * (kuvvet + 150), ForceMode.Acceleration);
        }
        else if ((MainMesh.eulerAngles.z < -60 && gameObject.GetComponent<Rigidbody>().velocity.x > 9))
        {
            MainMesh.GetComponent<Rigidbody>().AddTorque(-transform.forward * Time.deltaTime * (kuvvet + 150), ForceMode.Acceleration);
        }
        else
        {
            if (gazla)
            {
                MainMesh.GetComponent<Rigidbody>().AddTorque(-transform.forward * Time.deltaTime * (kuvvet), ForceMode.Acceleration);
            }
            else
            {
                MainMesh.GetComponent<Rigidbody>().AddTorque(transform.forward * Time.deltaTime * (kuvvet + 70), ForceMode.Acceleration);
            }
        }

        if (yapay_basladi)
        {

            if (gazla)
            {//gas
                for (int i = 0; i < Wheels.Length - 2; i++)
                {
                    Wheels[i].GetComponent<Rigidbody>().AddTorque(-RPM * Wheels[i].transform.forward * 32f * Time.deltaTime, ForceMode.Acceleration);
                }

                exhaust.transform.GetChild(1).GetComponentInChildren<ParticleSystem>().startSize = Mathf.Lerp(exhaust.transform.GetChild(1).GetComponentInChildren<ParticleSystem>().startSize, 0, 5 * Time.deltaTime);


                if (exhaust != null)
                {

                    botnitrotimer2 += 1 * Time.deltaTime;
                    if (botNitrotimer < botnitrotimer2 && timer <= 4 && timer >= 0)
                    {
                        timer -= 1 * Time.deltaTime;
                        exhaust.transform.GetChild(0).gameObject.SetActive(true);
                        exhaust.transform.GetChild(1).gameObject.SetActive(false);
                        MainMesh.GetComponent<Rigidbody>().AddForce(MainMesh.transform.right * 35000);
                    }
                    else
                    {
                        exhaust.transform.GetChild(0).gameObject.SetActive(false);
                        exhaust.transform.GetChild(1).gameObject.SetActive(true);
                    }
                }
            }
            if (!gazla)
            {//fren
                botnitrotimer2 = 0;
                timer = 4;
                for (int i = 0; i < Wheels.Length; i++)
                {
                    Wheels[i].GetComponent<Rigidbody>().AddTorque(RPM * Wheels[i].transform.forward * 32f * Time.deltaTime, ForceMode.Force);
                }
            }
        }
    }

    IEnumerator bekk(float i)
    {
        temp2 = i;
        beks = true;
        yield return new WaitForSecondsRealtime(temp2);
        beks = false;
        if (Benzin <= 0)
        {
            finishFren = true;
            canvas.GetComponent<oyunici>().benzindip = true;
        }
    }
    GameObject canvas;
    public void Update()
    {
        //transform.GetChild(0).localEulerAngles = new Vector3(0, 0, transform.GetChild(0).localEulerAngles.z);
        if (gameStart == true)
        {
            gameStart = false;
            StartSound.GetComponent<AudioSource>().Play();
            StartSound.GetComponent<AudioSource>().volume = Mathf.Lerp(StartSound.GetComponent<AudioSource>().volume, 0f, Time.deltaTime * 50);
        }
      

    }
    void LateUpdate()
    {
        if (yapay_basladi)
        {
            if (Time.frameCount % 50 == 0)
            {
                Temp_pos = MainMesh.position;
            }
            if (Time.frameCount % 134 == 0)
            {
                if (Temp_pos.x + 0.01f >= MainMesh.position.x && Temp_pos.x - 0.01f <= MainMesh.position.x - 0.01f)
                {
                    gazla = false;
                }
                else
                {
                    gazla = true;
                }
            }
        }

        if (transform.tag != "yapay")
        {
            if (beks)
            {
                if (Benzin > 0)
                {
                    canvas.GetComponent<Canvas>().enabled = true;
                    temp2 = 0;
                    once2 = true;
                }
            }

            if (Benzin > 20)
            {
                onceben = true;
            }

           
                
            if (Benzin <= 20 && onceben && PlayerPrefs.GetInt("BonusMap") != 0 && Benzin>0)
            {
                GameObject.Instantiate(benzin_spawn, new Vector3(transform.GetChild(0).position.x + Random.Range(25, 60), transform.GetChild(0).position.y + 180, transform.GetChild(0).position.z), Quaternion.identity);
                onceben = false;
                
            }
            if (Benzin <= 0)
            {
                oyunici.deadZoom = true;
                StartCoroutine(bekk(2));
            }
        }
        else if (transform.tag != "yapay")
        {
            if (beks)
            {
                if (Benzin > 0)
                {
                    temp2 = 0;
                    once2 = true;
                }
            }

            if (Benzin > 20)
            {
                onceben = true;
            }

            if (Benzin <= 0)
            {
                if (once2)
                {
                    canvas = GameObject.Find("Canvas");
                    StartCoroutine(bekk(3));
                    once2 = false;
                }
            }
        }
    }

}

