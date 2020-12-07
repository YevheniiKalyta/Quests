using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int gold = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position +=new Vector3 (Input.GetAxis("Horizontal"), 0 ,Input.GetAxis("Vertical"))*Time.deltaTime*speed;

    }
}
