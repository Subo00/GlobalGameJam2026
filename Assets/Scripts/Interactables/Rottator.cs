using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rottator : Trigger
{
    
    public override void DoTheThing()
    {
        transform.Rotate(0f, 90f, 0f);
    }

    public override void DoTheOtherThing()
    {
        transform.Rotate(0f, -90f, 0f);
    }
}
