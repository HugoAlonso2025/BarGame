using UnityEngine;

public class LimeBehaviour : MonoBehaviour
{
    bool onGlass;

    LimeOnGlass glass;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "glass" && !onGlass)
        {
            glass = collision.gameObject.GetComponentInChildren<LimeOnGlass>();
            glass.ActivateLime();
            Destroy(gameObject);
        }
    }


}
