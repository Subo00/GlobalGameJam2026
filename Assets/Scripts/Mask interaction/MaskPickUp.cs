using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskPickUp : PickUp
{
    [SerializeField] Mask mask;
    protected override void OnPickUp()
    {
        MaskChanger.Instance.UnlockMask(mask);
        MaskChanger.Instance.ChangeMask(mask);
    }
}
