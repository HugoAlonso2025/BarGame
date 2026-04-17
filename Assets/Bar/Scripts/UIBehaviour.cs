using BNG;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] Transform _UIPos;
    BNGPlayerController player;
    Vector3 pos;

    [SerializeField] GameObject _purpleText;
    [SerializeField] GameObject _greenText;
    [SerializeField] GameObject _orangeText;
    [SerializeField] GameObject _blueText;
    [SerializeField] GameObject _redText;
    [SerializeField] GameObject _yellowText;
    [SerializeField] GameObject _errorText;

    private void Start()
    {
        player = FindAnyObjectByType<BNGPlayerController>();
    }

    private void Update()
    {
        transform.position = _UIPos.position;

        pos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(pos);
    }

    public void SetActiveBlue()
    {
        _blueText.SetActive(true);
    }

    public void SetActiveRed()
    {
        _redText.SetActive(true);
    }

    public void SetActiveYellow()
    {
        _yellowText.SetActive(true);
    }

    public void SetActiveError()
    {
        _errorText.SetActive(true);
    }

    public void SetActiveOrange()
    {
        _orangeText.SetActive(true);
    }

    public void SetActiveGreen()
    {
        _greenText.SetActive(true);
    }

    public void SetActivePurple()
    {
        _purpleText.SetActive(true);
    }


}
