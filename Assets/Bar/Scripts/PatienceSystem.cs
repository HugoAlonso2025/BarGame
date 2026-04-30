using UnityEngine;
using UnityEngine.UI;

public class PatienceSystem : MonoBehaviour
{

    [SerializeField] float maxTime = 100;
    float currentTime;

    Image timeBar;

    public bool timeOut;

    private void Start()
    {
        timeBar = GetComponent<Image>();
        currentTime = maxTime;
    }

    private void Update()
    {
        timeBar.fillAmount = currentTime * 0.01f;
        currentTime -= Time.deltaTime;

        if (currentTime <= 0 && !timeOut)
        {
            timeOut = true;
            Debug.Log("Time out");
        }
    }
}
