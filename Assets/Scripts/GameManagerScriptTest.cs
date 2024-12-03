using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManagerScriptTest : MonoBehaviour
{
    public GameObject[] _cars;
    public static int _carIndex;
    float timer=3;
    public Camera _gameCamera;
    bool test;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _cars.Length; i++)
        {
            _cars[i].gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_carIndex==2 && !test)
        {
            test = true;
            _gameCamera.transform.DOShakePosition(.4f,.5f);           
        }

        timer -= 1*Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow) && timer<0)
        {
            timer = 3;
            _carIndex += 1;
        }
       
        for (int i = 0; i < _cars.Length; i++)
        {
            if (_carIndex!=i)
            {
                _cars[i].gameObject.SetActive(false);
            }
            else
            {
                _cars[_carIndex].gameObject.SetActive(true);
            }
        }
    }
   
}
