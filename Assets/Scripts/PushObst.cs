using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObst : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTheObst();
    }

    void MoveTheObst(){
        transform.Translate(0,0,dir*moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("WallLimits")){
            dir *= -1;
        }
    }
}
