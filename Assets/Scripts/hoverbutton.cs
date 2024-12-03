using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hoverbutton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource clickonsound, clickoffsound;
    Vector3 resetvector;
    public void Start()
    {
        resetvector = gameObject.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x*1.05f, gameObject.transform.localScale.y*1.05f, gameObject.transform.localScale.z);

      //  clickonsound.Play();
    //    gamecontrol.hoverbool = true;
        //do stuff
    }
    public void OnPointerExit(PointerEventData eventData)
    {

        gameObject.transform.localScale = resetvector;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.transform.localScale = resetvector;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 0.95f, gameObject.transform.localScale.y * 0.95f, gameObject.transform.localScale.z);
       // clickonsound.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.transform.localScale = resetvector;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 1.05f, gameObject.transform.localScale.y * 1.05f, gameObject.transform.localScale.z);


       // clickoffsound.Play();

        //gamecontrol.clickbool = true; 
    }
}
