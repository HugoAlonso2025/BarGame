using System.Collections;
using UnityEngine;

public class IceBehaviour : MonoBehaviour
{
    [SerializeField] Transform _icePosition;
    [SerializeField] Transform shovelRotation;
    [SerializeField] bool onGlass;

    CubesOnGlass glass;

    Rigidbody rb;
    BoxCollider col;

    bool wait = false;

    private void Start()
    {
        transform.position = _icePosition.position;   
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "glass" && !onGlass)
        {
            glass = other.gameObject.GetComponentInChildren<CubesOnGlass>();
            transform.position = _icePosition.position;
            rb.isKinematic = true;
            col.isTrigger = true;
            glass.ActivateCube();
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {

        if (shovelRotation.localEulerAngles.x > 40 && shovelRotation.localEulerAngles.x < 320 || shovelRotation.localEulerAngles.z > 60 && shovelRotation.localEulerAngles.z < 300)
        {
            StartCoroutine(CoolDown());
            StartCoroutine(Despawn());
            rb.isKinematic = false;
            //col.isTrigger = false;
        }
        else
        {
            if(!wait)
            {
                rb.isKinematic = true;
                col.isTrigger = true;
            }
        }
    }

    IEnumerator CoolDown()
    {
        wait = true;
        yield return new WaitForSeconds(2);
        wait = false;

    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = _icePosition.position;
        rb.isKinematic = true;
        col.isTrigger = true;
        gameObject.SetActive(false);
    }


}
