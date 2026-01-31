using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject plate;
    public Vector3 startingPos;
    public Vector3 endingPos;

    protected virtual void OnDown()
    {
        plate.transform.position = endingPos;
    }

    protected virtual void OnUp()
    {
        plate.transform.position = startingPos;
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
