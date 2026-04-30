using UnityEngine;
using UnityEngine.UI;

public class PatienceSystem : MonoBehaviour
{

    [SerializeField] float maxTime = 100;
    public float currentTime;

    Image timeBar;

    public bool timeOut;

    private void Start()
    {
        timeBar = GetComponent<Image>();
        currentTime = maxTime;
    }

    private void Update()
    {
        timeBar.fillAmount = currentTime * 0.0334f;
        currentTime -= Time.deltaTime;

        if (currentTime <= 0 && !timeOut)
        {
            timeOut = true;
            Debug.Log("Time out");
        }
    }
}
