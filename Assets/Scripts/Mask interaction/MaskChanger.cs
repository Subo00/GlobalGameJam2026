using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaskListener
{
    void OnMaskChange(Mask mask);
}

public enum Mask { NONE, RED, BLUE, GREEN };

public class MaskChanger : MonoBehaviour
{
    public static MaskChanger Instance;

    private List<MaskListener> maskListeners = new List<MaskListener>();
    private Mask currentMask;
    
    public void AddListener(MaskListener listener)
    {
        maskListeners.Add(listener);
    }

    public void RED()
    {
        ChangeMask(Mask.RED);
    }

    public void NONE()
    {
        ChangeMask(Mask.NONE);
    }

    public void ChangeMask(Mask mask)
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

    
}
