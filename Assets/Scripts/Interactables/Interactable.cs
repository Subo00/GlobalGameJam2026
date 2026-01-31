using UnityEngine;

public abstract class Interactable : MonoBehaviour, IMyUpdate
{
    protected Transform dropPoint = null;

    private PlayerHUD playerHUD = null;

    protected abstract void OnUpdate();
    void IMyUpdate.MyUpdate()
    {
        OnUpdate();
    }
    protected void CommonLogic()
    {
        playerHUD.ShowInteractionOnObject(dropPoint.position);
    }

    protected virtual void Start()
    {
        //Make sure that the gameObject dropPoint is a child of the GO
        //that this script is attached to
        Transform[] temp = gameObject.GetComponentsInChildren<Transform>();
        dropPoint = temp[1];
        playerHUD = PlayerHUD.Instance;
        if (dropPoint == null)
        {
            Debug.LogError("dropPoint game object can not be found!");
        }
    }

    public void OnEntry()
    {
        UpdateManager.Instance.AddUpdatable(this);

    }

    public void OnExit()
    {
        UpdateManager.Instance.RemoveUpdatable(this);
        PlayerHUD.Instance.HideInteraction();
    }
   
}