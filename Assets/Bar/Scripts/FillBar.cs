using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FillBar : MonoBehaviour
{
    Image bar;
    public int count;

    [SerializeField] bool isBlue;
    [SerializeField] bool isRed;
    [SerializeField] bool isYellow;

    [SerializeField] TMP_Text textCount;

    [SerializeField] GlassFillingUp glass;

    private void Start()
    {
        bar = GetComponent<Image>();
    }

    private void Update()
    {
        if (isBlue)
        {
            count = (int)glass.blueCount;
        }
        else if (isRed)
        {
            count = (int)glass.redCount;
        }
        else if(isYellow)
        {
            count = (int)glass.yellowCount;
        }

        bar.fillAmount = count * 0.01f;

        if (count < 0) count = 0;
        if (count > 100) count = 100;

        textCount.text = count.ToString();
    }

    


}
