using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaskListener
{
    void OnMaskChange(Mask mask);
}

public enum Mask { NONE, BLUE, RED, GREEN, COUNT };

public class MaskChanger : MonoBehaviour
{
    public static MaskChanger Instance;

    private List<MaskListener> maskListeners = new List<MaskListener>();
    private Mask currentMask;
    private bool[] unlockedMasks = new bool[(int)Mask.COUNT - 1];

    public void AddListener(MaskListener listener)
    {
        maskListeners.Add(listener);
    }

    public void UnlockMask(Mask mask)
    {
        unlockedMasks[(int)mask] = true;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && unlockedMasks[(int)Mask.NONE])
        {
            ChangeMask(Mask.NONE);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && unlockedMasks[(int)Mask.BLUE])
        {
            ChangeMask(Mask.BLUE);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) && unlockedMasks[(int)Mask.RED])
        {
            ChangeMask(Mask.RED);
        }
    }

}
