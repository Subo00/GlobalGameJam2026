using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject plate;
    [SerializeField] private Trigger triggerDown;
    [SerializeField] private Trigger triggerUp;
    public Vector3 startingPos;
    public Vector3 endingPos;

    protected virtual void OnDown()
    {
        plate.transform.position = endingPos;
        if (triggerDown != null) triggerDown.DoTheThing();
    }

    protected virtual void OnUp()
    {
        plate.transform.position = startingPos;
        if(triggerUp != null) triggerUp.DoTheThing();
    }

    private void Start()
    {
        startingPos = plate.transform.position;
        endingPos = startingPos;
        endingPos.y -= 0.05f;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnDown();
        }
       
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnUp();
        }
    }
}
