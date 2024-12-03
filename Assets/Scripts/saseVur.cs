using UnityEngine;
using System.Collections;
public class saseVur : MonoBehaviour
{
    // Use this for initialization
    public AudioClip[] clip;
    public GameObject _waterParticle;
    GameObject _waterSound;

    void Start()
    {
        _waterSound = GameObject.Find("WaterSound");
    }
    private void Update()
    {


    }
   

    void OnCollisionEnter(Collision coll)
    {
        if (transform.gameObject.tag != "yapay")
        {
            if (!transform.GetComponent<AudioSource>().isPlaying && coll.gameObject.tag == "iboreis")
            {
                transform.GetComponent<AudioSource>().clip = clip[Random.Range(0, clip.Length)];
                transform.GetComponent<AudioSource>().Play();
            }
        }



    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "water")
        {


            if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > 2.7f)
            {
                _waterParticle.SetActive(true);
               
            }
            else
            {
                _waterParticle.SetActive(false);
            }
            _waterSound.GetComponent<AudioSource>().enabled = true;
            this.gameObject.GetComponentInParent<truckk_yeni>().physicMaterial.dynamicFriction = this.gameObject.GetComponentInParent<truckk_yeni>().dynamicFrictionValue / 3;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().drag = 0.5f;
        }
        if (other.gameObject.tag == "ice")
        {


            if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > 2.7f)
            {
                _waterParticle.SetActive(true);

            }
            else
            {
                _waterParticle.SetActive(false);
            }

            this.gameObject.GetComponentInParent<truckk_yeni>().physicMaterial.dynamicFriction = this.gameObject.GetComponentInParent<truckk_yeni>().dynamicFrictionValue / 3;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            _waterParticle.SetActive(false);
            _waterSound.GetComponent<AudioSource>().enabled = false;
            this.gameObject.GetComponentInParent<truckk_yeni>().physicMaterial.dynamicFriction = this.gameObject.GetComponentInParent<truckk_yeni>().dynamicFrictionValue;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().drag = 0;
        }
        if (other.gameObject.tag == "ice")
        {
            _waterParticle.SetActive(false);
            this.gameObject.GetComponentInParent<truckk_yeni>().physicMaterial.dynamicFriction = this.gameObject.GetComponentInParent<truckk_yeni>().dynamicFrictionValue;

        }
    }
}
