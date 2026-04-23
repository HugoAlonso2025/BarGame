using System.Collections;
using UnityEngine;

public class RecoverObject : MonoBehaviour
{
    public Vector3 _objPos;
    Rigidbody rb;

    private void Start()
    {
        _objPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "floor")
        {
            StartCoroutine(SetKine());
            transform.rotation = Quaternion.identity;
            transform.position = _objPos;
        }
    }

    IEnumerator SetKine()
    {
        rb.isKinematic = true;
        yield return new WaitForSeconds(1);
        rb.isKinematic = false;
    }
}
