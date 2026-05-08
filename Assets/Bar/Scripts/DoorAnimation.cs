using System.Collections;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] Animator leftDoor;
    [SerializeField] Animator rightDoor;
    [SerializeField] float radius;
    [SerializeField] LayerMask customer;
    bool customerDetected;

    private void Update()
    {
        CheckArea();
    }

    void CheckArea()
    {
        if(Physics.CheckSphere(transform.position, radius, customer))
        {
            customerDetected = true;
        }
        else
        {
            customerDetected = false;
        }
    }

    public void OpenDoorEnter()
    {
        leftDoor.SetBool("Entrar", true);
        rightDoor.SetBool("Entrar", true);
        leftDoor.SetBool("Cerrar", false);
        rightDoor.SetBool("Cerrar", false);
        StartCoroutine(CloseDoorOnEntry());
    }

    public void OpenDoorExit()
    {
        leftDoor.SetBool("Salir", true);
        rightDoor.SetBool("Salir", true);
        leftDoor.SetBool("Cerrar", false);
        rightDoor.SetBool("Cerrar", false);
        StartCoroutine(CloseDoorOnEntry());
    }

    IEnumerator CloseDoorOnEntry()
    {
        yield return new WaitForSeconds(4);
        
        if (!customerDetected)
        {
        }
        else
        {
            yield return new WaitForSeconds(6);
        }

        leftDoor.SetBool("Cerrar", true);
        leftDoor.SetBool("Entrar", false);
        leftDoor.SetBool("Salir", false);
        rightDoor.SetBool("Cerrar", true);
        rightDoor.SetBool("Entrar", false);
        rightDoor.SetBool("Salir", false);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
