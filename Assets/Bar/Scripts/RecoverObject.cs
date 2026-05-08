using System.Collections;
using UnityEngine;

public class RecoverObject : MonoBehaviour
{
    public Vector3 _objPos;
    public Quaternion _objRot;
    Rigidbody rb;
    SoundManager sound;
    [SerializeField] AudioClip dropSound;

    private void Start()
    {
        _objPos = transform.position;
        _objRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<SoundManager>();   
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "floor")
        {
            StartCoroutine(SetKine());
            transform.rotation = _objRot;
            transform.position = _objPos;
            sound.PlaySound(dropSound);
        }
    }

    IEnumerator SetKine()
    {
        rb.isKinematic = true;
        yield return new WaitForSeconds(1);
        rb.isKinematic = false;
    }
}
