using BNG;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] Transform _UIPos;
    BNGPlayerController player;
    Vector3 pos;

    [SerializeField] GameObject _blue;
    [SerializeField] GameObject _blueHielo;
    [SerializeField] GameObject _blueLima;
    [SerializeField] GameObject _blueHieloLima;
    [SerializeField] GameObject _red;
    [SerializeField] GameObject _redHielo;
    [SerializeField] GameObject _redLima;
    [SerializeField] GameObject _redHieloLima;
    [SerializeField] GameObject _yellow;
    [SerializeField] GameObject _yellowHielo;
    [SerializeField] GameObject _yellowLima;
    [SerializeField] GameObject _yellowHieloLima;
    [SerializeField] GameObject _orange;
    [SerializeField] GameObject _orangeHielo;
    [SerializeField] GameObject _orangeLima;
    [SerializeField] GameObject _orangeHieloLima;
    [SerializeField] GameObject _green;
    [SerializeField] GameObject _greenHielo;
    [SerializeField] GameObject _greenLima;
    [SerializeField] GameObject _greenHieloLima;
    [SerializeField] GameObject _purple;
    [SerializeField] GameObject _purpleHielo;
    [SerializeField] GameObject _purpleLima;
    [SerializeField] GameObject _purpleHieloLima;

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

    public void SetActiveBlueLima()
    {
        _blueLima.SetActive(true);
    }

    public void SetActiveRedLima()
    {
        _redLima.SetActive(true);
    }

    public void SetActiveYellowLima()
    {
        _yellowLima.SetActive(true);
    }

    public void SetActiveOrangeLima()
    {
        _orangeLima.SetActive(true);
    }

    public void SetActiveGreenLima()
    {
        _greenLima.SetActive(true);
    }

    public void SetActivePurpleLima()
    {
        _purpleLima.SetActive(true);
    }
    public void SetActiveBlueHieloLima()
    {
        _blueHieloLima.SetActive(true);
    }
    public void SetActiveRedHieloLima()
    {
        _redHieloLima.SetActive(true);
    }
    public void SetActiveYellowHieloLima()
    {
        _yellowHieloLima.SetActive(true);
    }
    public void SetActiveOrangeHieloLima()
    {
        _orangeHieloLima.SetActive(true);
    }
    public void SetActiveGreenHieloLima()
    {
        _greenHieloLima.SetActive(true);
    }
    public void SetActivePurpleHieloLima()
    {
        _purpleHieloLima.SetActive(true);
    }


}
