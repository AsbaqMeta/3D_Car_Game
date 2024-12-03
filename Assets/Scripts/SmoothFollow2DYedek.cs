using UnityEngine;
using System.Collections;

public class SmoothFollow2DYedek : MonoBehaviour
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
    public Camera cam;
    public float camViewDefaultFov = 60;
    public float camvieWSpeed=35;
    public float whatCamera;
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

       
        
            if (canvas.GetComponent<oyunici>().olme != true )
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, (canvas.GetComponent<oyunici>().player.GetComponent<Rigidbody>().velocity.magnitude *2) + 30, Time.smoothDeltaTime);
            }
            else
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 30, camvieWSpeed * Time.deltaTime);
            }

            if (m_Target == null)
            {
                m_Target = GameObject.FindGameObjectWithTag("Player");
            }
            else
            {
                if (karakter2.activeSelf)
                {
                  
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
    }
}