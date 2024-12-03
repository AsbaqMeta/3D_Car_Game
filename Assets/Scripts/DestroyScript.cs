using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public string coin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coin=="coin")
        {
            if (gameObject.transform.GetChild(0).transform.localScale.x==0)
            {
                Destroy(gameObject);
            }
        }
    }
}
