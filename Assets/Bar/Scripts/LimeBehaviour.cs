using UnityEngine;

public class LimeBehaviour : MonoBehaviour
{
    bool onGlass;

    LimeOnGlass glass;
    RespawnLime lime;

    private void Start()
    {
        lime = GetComponent<RespawnLime>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "glass" && !onGlass)
        {
            glass = collision.gameObject.GetComponentInChildren<LimeOnGlass>();
            glass.ActivateLime();
            lime.InstantiateLime();
            Destroy(gameObject);
        }
    }


}
