using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    float timer = 0f;
    public float delay = 1f;

    protected override void OnUpdate()
    {
        CommonLogic();
        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.E) && timer >= delay)
        {
            timer = 0f;
            Debug.Log("I DID A THING!"); //add a thing to do (LOL)
        }

    }


}
