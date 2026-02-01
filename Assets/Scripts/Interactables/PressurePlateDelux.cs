using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDelux : PressurePlate
{
    [SerializeField] private Material oneColor;
    [SerializeField] private Material twoColor;
    public bool isOne = true;

    protected override void OnDown()
    {
        isOne = !isOne;
        plate.GetComponent<MeshRenderer>().material = isOne? oneColor : twoColor;
        base.OnDown();
    }
}
