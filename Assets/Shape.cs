using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{

    public string shapeName;

    // Start is called before the first frame update
    public virtual void Start()
    {
        Debug.Log("Hellow, my shape is " + shapeName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
