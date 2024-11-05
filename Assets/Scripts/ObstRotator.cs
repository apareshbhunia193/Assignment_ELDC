using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstRotator : MonoBehaviour
{

    [SerializeField] float rotationalSpeed = 5f;
    [SerializeField] float rotationalAngle = 1f;
    [SerializeField] bool isItCollectable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateTheObject();
    }

    void RotateTheObject(){
        if(!isItCollectable)
            transform.Rotate(0,rotationalAngle * rotationalSpeed * Time.deltaTime,0);
        else
            transform.Rotate(0, 0, rotationalAngle * rotationalSpeed * Time.deltaTime);
    }
}
