using UnityEngine;

public class LimeOnGlass : MonoBehaviour
{
    [SerializeField] GameObject _limeObject;
    public bool limeOn;

    public void ActivateLime()
    {
        _limeObject.SetActive(true);
    }

    public void LimeCheck()
    {
        if (_limeObject.activeSelf)
        {
            limeOn = true;
        }
    }
}
