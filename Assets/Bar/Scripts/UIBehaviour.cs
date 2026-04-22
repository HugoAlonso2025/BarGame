using BNG;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] Transform _UIPos;
    BNGPlayerController player;
    Vector3 pos;

    [SerializeField] GameObject _purple;
    [SerializeField] GameObject _green;
    [SerializeField] GameObject _orange;
    [SerializeField] GameObject _blue;
    [SerializeField] GameObject _red;
    [SerializeField] GameObject _yellow;
    [SerializeField] GameObject _purpleHielo;
    [SerializeField] GameObject _greenHielo;
    [SerializeField] GameObject _orangeHielo;
    [SerializeField] GameObject _blueHielo;
    [SerializeField] GameObject _redHielo;
    [SerializeField] GameObject _yellowHielo;

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
        _blue.SetActive(true);
    }

    public void SetActiveRed()
    {
        _red.SetActive(true);
    }

    public void SetActiveYellow()
    {
        _yellow.SetActive(true);
    }

    public void SetActiveOrange()
    {
        _orange.SetActive(true);
    }

    public void SetActiveGreen()
    {
        _green.SetActive(true);
    }

    public void SetActivePurple()
    {
        _purple.SetActive(true);
    }
    public void SetActiveBlueHielo()
    {
        _blueHielo.SetActive(true);
    }

    public void SetActiveRedHielo()
    {
        _redHielo.SetActive(true);
    }

    public void SetActiveYellowHielo()
    {
        _yellowHielo.SetActive(true);
    }

    public void SetActiveOrangeHielo()
    {
        _orangeHielo.SetActive(true);
    }

    public void SetActiveGreenHielo()
    {
        _greenHielo.SetActive(true);
    }

    public void SetActivePurpleHielo()
    {
        _purpleHielo.SetActive(true);
    }


}
