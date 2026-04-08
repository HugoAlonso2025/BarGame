using UnityEngine;

public class IceBehaviour : MonoBehaviour
{
    [SerializeField] Transform _icePosition;
    [SerializeField] bool onGlass;

    CubesOnGlass glass;

    private void Start()
    {
        transform.position = _icePosition.position;   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor" && !onGlass)
        {
            transform.position = _icePosition.position;
            gameObject.SetActive(false);
        }

        if(collision.gameObject.tag == "glass" && !onGlass)
        {
            glass = collision.gameObject.GetComponent<CubesOnGlass>();
            transform.position = _icePosition.position;
            glass.ActivateCube();
            gameObject.SetActive(false);
        }
    }


}
