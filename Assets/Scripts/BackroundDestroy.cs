using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackroundDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        if(oyunici.carDistanceCounter>this.transform.position.x+500 && (this.transform.position.z == 80 || this.transform.position.z==60 || this.transform.position.z == 10 || this.transform.position.z == 0))
        {

            Destroy(this.gameObject);

        }
    }
}
