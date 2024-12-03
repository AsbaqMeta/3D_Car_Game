using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class SmoothFollow2D : MonoBehaviour
{
    private GameObject canvas;
    public GameObject karakter1, karakter2;
    //offset from the viewport center to fix damping
    public float m_DampTime = 10f;
    public GameObject m_Target;
    public float m_XOffset = 0;
    public float m_YOffset = 0;
    public float m_ZOffset = 0;
    private float margin = 0.1f;
    private Vector3 temp_pos;
    private Quaternion temp_rot;
    public Camera cam;
    public float camViewDefaultFov = 60;
    public float camvieWSpeed=35;
    public float whatCamera;
    public Text cameraText;
    public Text cameraposition;
    void Start()
    {
        
        if (whatCamera == 0)
        {
            transform.GetComponent<Camera>().enabled = false;
        }
        oyunici.deadZoom=false;
        canvas = GameObject.Find("Canvas");
        temp_pos = transform.position;
        //Invoke("bek", 5);
        karakter1 = canvas.GetComponent<oyunici>().arac_karakteri.GetComponent<adam_oldu>().adam2;
        karakter2 = canvas.GetComponent<oyunici>().arac_karakteri.GetComponent<adam_oldu>().adam3;
    }
   
    void Update()
    {
       

        if (whatCamera == 1)
        {
           
            if (canvas.GetComponent<oyunici>().olme != true )
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, (canvas.GetComponent<oyunici>().player.GetComponent<Rigidbody>().velocity.magnitude *2) + 30, Time.smoothDeltaTime);
            }
            else
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 30, camvieWSpeed * Time.deltaTime);
            }
            //if (canvas.GetComponent<oyunici>().olme == true)
            //{
            //    cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 27, camvieWSpeed * 2.1f * Time.deltaTime);
            //}
            //if (air_time.carAir == true)
            //{
            //    cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 45, camvieWSpeed *  Time.deltaTime); ;
            //}
            //if (air_time.carAir == false)
            //{
            //    cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 35, camvieWSpeed * 1.6f * Time.deltaTime);
            //}
            //if (oyunici.deadZoom)
            //{
            //    cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 20, camvieWSpeed * 2.1f * Time.deltaTime);
            //    Debug.Log("Zoom Yaptı");
            //}
            if (m_Target == null)
            {
                m_Target = canvas.GetComponent<oyunici>().player.transform.GetChild(0).gameObject;
            }
            else
            {
                if (karakter2.activeSelf)
                {
                    Debug.Log("2. Kez öldü");
                    //transform.position = Vector3.Lerp(transform.position, new Vector3(karakter2.transform.position.x, karakter2.transform.position.y + 15, karakter2.transform.position.z - 2.5f), Time.deltaTime * 1);
                    transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0, 0), Time.deltaTime * 1);
                }
                else if (karakter1.activeSelf)
                {
                    float targetX = karakter1.transform.GetChild(7).position.x + m_XOffset;
                    float targetY = karakter1.transform.GetChild(7).position.y + m_YOffset;
                    float targetZ = karakter1.transform.GetChild(7).position.z + m_ZOffset;
                    targetY = Mathf.Lerp(transform.position.y, targetY, m_DampTime * Time.deltaTime);
                    transform.position = new Vector3(targetX, targetY, targetZ);
                }
                else
                {
                    if (m_Target)
                    {
                        float targetX = m_Target.transform.position.x + m_XOffset;
                        float targetY = m_Target.transform.position.y + m_YOffset;
                        float targetZ = m_Target.transform.position.z + m_ZOffset;
                        targetY = Mathf.Lerp(transform.position.y, targetY, m_DampTime * Time.deltaTime);
                        transform.position = new Vector3(targetX, targetY, targetZ);
                    }
                }
            }
              if(PlayerPrefs.GetInt("BonusMap")==0)
        {
          /*   cameraText.text=m_Target.name;
            cameraposition.text=transform.position.ToString(); */

        }

        }
       
        if (whatCamera==0)
        {
            if (canvas.GetComponent<oyunici>().olme != true )
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, (canvas.GetComponent<oyunici>().player.GetComponent<Rigidbody>().velocity.magnitude ) + 15, Time.smoothDeltaTime/3f);
            }
            else
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 15, camvieWSpeed * Time.deltaTime);
            }
            //if (air_time.carAir == true)
            //{
            //    Debug.Log("camera zoom");
            //    cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 23.5f, camvieWSpeed * Time.deltaTime);
            //}
            //if(air_time.carAir==false)
            //{
            //    cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 15, camvieWSpeed * 2.5f * Time.deltaTime);
            //}
            //  if(oyunici.deadZoom)
            //{
            //    cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 7, camvieWSpeed * 3.5f  * Time.deltaTime);
            //}
            if (m_Target == null)
            {
                m_Target = GameObject.FindGameObjectWithTag("Player");
            }
            else
            {
                if (karakter2.activeSelf)
                {
                 // transform.position = Vector3.Lerp(transform.position, new Vector3(karakter2.transform.position.x, karakter2.transform.position.y + 15, karakter2.transform.position.z - 2.5f), Time.deltaTime * 1);
                    transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0, 0), Time.deltaTime * 1);
                }
                else if (karakter1.activeSelf)
                {
                    float targetX = karakter1.transform.position.x + m_XOffset;
                    float targetY = karakter1.transform.position.y + m_YOffset;
                    float targetZ = karakter1.transform.position.z + m_ZOffset;
                    targetY = Mathf.Lerp(transform.position.y, targetY, m_DampTime * Time.deltaTime);
                    transform.position = new Vector3(targetX, targetY, targetZ);
                }
                else
                {
                    if (m_Target)
                    {
                        float targetX = m_Target.transform.position.x + m_XOffset;
                        float targetY = m_Target.transform.position.y + m_YOffset;
                        float targetZ = m_Target.transform.position.z + m_ZOffset;
                        targetY = Mathf.Lerp(transform.position.y, targetY, m_DampTime * Time.deltaTime);
                        transform.position = new Vector3(targetX, targetY, targetZ);
                    }
                }
            }

        }
      
    }
    
  public void _2DCamera()
    {
        if(whatCamera==0)
        {
            transform.GetComponent<Camera>().enabled = true;
        }
        
    }
    public void _3DCamera()
    {
        if (whatCamera ==0)
        {
            transform.GetComponent<Camera>().enabled = false;
        }
       
    }
}
