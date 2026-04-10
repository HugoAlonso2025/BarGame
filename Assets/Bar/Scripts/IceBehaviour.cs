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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor" && !onGlass)
        {
            transform.position = _icePosition.position;
            rb.isKinematic = true;
            col.isTrigger = true;
            gameObject.SetActive(false);
        }

        if(collision.gameObject.tag == "glass" && !onGlass)
        {
            glass = collision.gameObject.GetComponentInChildren<CubesOnGlass>();
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
            col.isTrigger = false;
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
        yield return new WaitForSeconds(2);
        transform.position = _icePosition.position;
        rb.isKinematic = true;
        col.isTrigger = true;
        gameObject.SetActive(false);
    }


}
