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
        glass = collision.gameObject.GetComponentInChildren<LimeOnGlass>();

        if (glass != null && collision.gameObject.tag == "glass" && !onGlass && !glass.limeOn)
        {
            glass.limeOn = true;
            glass.ActivateLime();
            lime.InstantiateLime();
            Destroy(gameObject);
        }
    }


}
