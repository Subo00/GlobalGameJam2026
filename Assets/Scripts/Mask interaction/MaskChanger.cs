using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaskListener
{
    void OnMaskChange(Mask mask);
}

public enum Mask { NONE, BLUE, RED, GREEN };

public class MaskChanger : MonoBehaviour
{
    public static MaskChanger Instance;

    private List<MaskListener> maskListeners = new List<MaskListener>();
    private Mask currentMask;
    
    public void AddListener(MaskListener listener)
    {
        maskListeners.Add(listener);
    }

    private void ChangeMask(Mask mask)
    {
        currentMask = mask;
        foreach (MaskListener listener in maskListeners)
        {
            listener.OnMaskChange(mask);
        }
    }

    private void Awake()
    {
        if (Instance == null){ Instance = this; }
        else { Destroy(gameObject); }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeMask(Mask.NONE);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeMask(Mask.BLUE);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeMask(Mask.RED);
        }
    }

}
