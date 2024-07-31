using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Shape
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Debug.Log("I am inherited from Shape");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
