using UnityEngine;

public class EntrenceHall : MonoBehaviour, IMyUpdate
{
    [SerializeField] private Rottator[] rotators;

    private void Start()
    {
        if (UpdateManager.Instance == null) Debug.Log("KAKO?!");
        UpdateManager.Instance.AddUpdatable(this);
    }
    public void MyUpdate()
    {
        foreach (var rotator in rotators)
        {
            if (rotator.state != State.SOUTH) return;
        }

        Debug.Log("WUUUU");
        UpdateManager.Instance.RemoveUpdatable(this);
    }
}
