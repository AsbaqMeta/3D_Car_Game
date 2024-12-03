using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCracked : MonoBehaviour
{

    // -Kutular
    // -Odunlar
    // -Köprüler
    // -Rampalar
    // -Taşlar
    public GameObject _woodSound;
    public GameObject _boxCrackedSound;
    private float _billetToCarDistance;
    public string _WhatObject;
    public GameObject[] SpawnBody, crackedBody;
    public bool spawn;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        _boxCrackedSound = GameObject.Find("BoxCrackedSound");
         _woodSound = GameObject.Find("WoodSound");
        spawn = false;
        canvas = GameObject.Find("Canvas");
    }
  

    // Update is called once per frame
    void Update()
    {

        if (_WhatObject == "BilletObject")
        {
            _billetToCarDistance = Vector3.Distance(transform.position, canvas.GetComponent<oyunici>().player.transform.position);
            if (_billetToCarDistance < 35)
            {
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (_WhatObject == "CarObject")
        {
            if (other.gameObject.layer == 10 || other.gameObject.layer == 17 || other.gameObject.layer == 13)
            {

                //if(canvas.GetComponent<oyunici>().player.GetComponent<Rigidbody>().velocity.magnitude>=3f)
                //{
                for (int i = 0; i < SpawnBody.Length; i++)
                {
                    if (SpawnBody != null)
                    {
                        Instantiate(SpawnBody[i], transform.position, transform.rotation);
                    }
                }
                for (int i = 0; i < crackedBody.Length; i++)
                {
                    Destroy(crackedBody[i]);
                }
                //}

            }
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (_WhatObject == "WoodObject")
        {

            if (other.gameObject.layer == 9)
            {

                _woodSound.GetComponent<AudioSource>().Play();

            }

        }
        if (_WhatObject == "BoxObject")
        {
            if (other.gameObject.layer == 8)
            {
                _boxCrackedSound.GetComponent<AudioSource>().Play();
                for (int i = 0; i < SpawnBody.Length; i++)
                {
                    if (SpawnBody != null)
                    {
                        Instantiate(SpawnBody[i], transform.position, transform.rotation);
                        SpawnBody[i].GetComponent<ParticleSystem>().Play();
                    }
                }
                for (int i = 0; i < crackedBody.Length; i++)
                {
                    Destroy(this.gameObject);
                }
            }
        }

    }
}
