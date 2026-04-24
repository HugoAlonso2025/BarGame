using BNG;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] Transform _UIPos;
    BNGPlayerController player;
    Vector3 pos;

    [SerializeField] GameObject _blueV;
    [SerializeField] GameObject _blueHieloV;
    [SerializeField] GameObject _blueLimaV;
    [SerializeField] GameObject _blueHieloLimaV;
    [SerializeField] GameObject _redV;
    [SerializeField] GameObject _redHieloV;
    [SerializeField] GameObject _redLimaV;
    [SerializeField] GameObject _redHieloLimaV;
    [SerializeField] GameObject _yellowV;
    [SerializeField] GameObject _yellowHieloV;
    [SerializeField] GameObject _yellowLimaV;
    [SerializeField] GameObject _yellowHieloLimaV;
    [SerializeField] GameObject _orangeV;
    [SerializeField] GameObject _orangeHieloV;
    [SerializeField] GameObject _orangeLimaV;
    [SerializeField] GameObject _orangeHieloLimaV;
    [SerializeField] GameObject _greenV;
    [SerializeField] GameObject _greenHieloV;
    [SerializeField] GameObject _greenLimaV;
    [SerializeField] GameObject _greenHieloLimaV;
    [SerializeField] GameObject _purpleV;
    [SerializeField] GameObject _purpleHieloV;
    [SerializeField] GameObject _purpleLimaV;
    [SerializeField] GameObject _purpleHieloLimaV;

    [SerializeField] GameObject _blueC;
    [SerializeField] GameObject _blueHieloC;
    [SerializeField] GameObject _blueLimaC;
    [SerializeField] GameObject _blueHieloLimaC;
    [SerializeField] GameObject _redC;
    [SerializeField] GameObject _redHieloC;
    [SerializeField] GameObject _redLimaC;
    [SerializeField] GameObject _redHieloLimaC;
    [SerializeField] GameObject _yellowC;
    [SerializeField] GameObject _yellowHieloC;
    [SerializeField] GameObject _yellowLimaC;
    [SerializeField] GameObject _yellowHieloLimaC;
    [SerializeField] GameObject _orangeC;
    [SerializeField] GameObject _orangeHieloC;
    [SerializeField] GameObject _orangeLimaC;
    [SerializeField] GameObject _orangeHieloLimaC;
    [SerializeField] GameObject _greenC;
    [SerializeField] GameObject _greenHieloC;
    [SerializeField] GameObject _greenLimaC;
    [SerializeField] GameObject _greenHieloLimaC;
    [SerializeField] GameObject _purpleC;
    [SerializeField] GameObject _purpleHieloC;
    [SerializeField] GameObject _purpleLimaC;
    [SerializeField] GameObject _purpleHieloLimaC;

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

    public void SetActiveBlueV()
    {
        _blueV.SetActive(true);
    }

    public void SetActiveRedV()
    {
        _redV.SetActive(true);
    }

    public void SetActiveYellowV()
    {
        _yellowV.SetActive(true);
    }

    public void SetActiveOrangeV()
    {
        _orangeV.SetActive(true);
    }

    public void SetActiveGreenV()
    {
        _greenV.SetActive(true);
    }

    public void SetActivePurpleV()
    {
        _purpleV.SetActive(true);
    }
    public void SetActiveBlueHieloV()
    {
        _blueHieloV.SetActive(true);
    }

    public void SetActiveRedHieloV()
    {
        _redHieloV.SetActive(true);
    }

    public void SetActiveYellowHieloV()
    {
        _yellowHieloV.SetActive(true);
    }

    public void SetActiveOrangeHieloV()
    {
        _orangeHieloV.SetActive(true);
    }

    public void SetActiveGreenHieloV()
    {
        _greenHieloV.SetActive(true);
    }

    public void SetActivePurpleHieloV()
    {
        _purpleHieloV.SetActive(true);
    }

    public void SetActiveBlueLimaV()
    {
        _blueLimaV.SetActive(true);
    }

    public void SetActiveRedLimaV()
    {
        _redLimaV.SetActive(true);
    }

    public void SetActiveYellowLimaV()
    {
        _yellowLimaV.SetActive(true);
    }

    public void SetActiveOrangeLimaV()
    {
        _orangeLimaV.SetActive(true);
    }

    public void SetActiveGreenLimaV()
    {
        _greenLimaV.SetActive(true);
    }

    public void SetActivePurpleLimaV()
    {
        _purpleLimaV.SetActive(true);
    }
    public void SetActiveBlueHieloLimaV()
    {
        _blueHieloLimaV.SetActive(true);
    }
    public void SetActiveRedHieloLimaV()
    {
        _redHieloLimaV.SetActive(true);
    }
    public void SetActiveYellowHieloLimaV()
    {
        _yellowHieloLimaV.SetActive(true);
    }
    public void SetActiveOrangeHieloLimaV()
    {
        _orangeHieloLimaV.SetActive(true);
    }
    public void SetActiveGreenHieloLimaV()
    {
        _greenHieloLimaV.SetActive(true);
    }
    public void SetActivePurpleHieloLimaV()
    {
        _purpleHieloLimaV.SetActive(true);
    }
    public void SetActiveBlueC()
    {
        _blueC.SetActive(true);
    }

    public void SetActiveRedC()
    {
        _redC.SetActive(true);
    }

    public void SetActiveYellowC()
    {
        _yellowC.SetActive(true);
    }

    public void SetActiveOrangeC()
    {
        _orangeC.SetActive(true);
    }

    public void SetActiveGreenC()
    {
        _greenC.SetActive(true);
    }

    public void SetActivePurpleC()
    {
        _purpleC.SetActive(true);
    }

    public void SetActiveBlueHieloC()
    {
        _blueHieloC.SetActive(true);
    }

    public void SetActiveRedHieloC()
    {
        _redHieloC.SetActive(true);
    }

    public void SetActiveYellowHieloC()
    {
        _yellowHieloC.SetActive(true);
    }

    public void SetActiveOrangeHieloC()
    {
        _orangeHieloC.SetActive(true);
    }

    public void SetActiveGreenHieloC()
    {
        _greenHieloC.SetActive(true);
    }

    public void SetActivePurpleHieloC()
    {
        _purpleHieloC.SetActive(true);
    }

    public void SetActiveBlueLimaC()
    {
        _blueLimaC.SetActive(true);
    }

    public void SetActiveRedLimaC()
    {
        _redLimaC.SetActive(true);
    }

    public void SetActiveYellowLimaC()
    {
        _yellowLimaC.SetActive(true);
    }

    public void SetActiveOrangeLimaC()
    {
        _orangeLimaC.SetActive(true);
    }

    public void SetActiveGreenLimaC()
    {
        _greenLimaC.SetActive(true);
    }

    public void SetActivePurpleLimaC()
    {
        _purpleLimaC.SetActive(true);
    }

    public void SetActiveBlueHieloLimaC()
    {
        _blueHieloLimaC.SetActive(true);
    }

    public void SetActiveRedHieloLimaC()
    {
        _redHieloLimaC.SetActive(true);
    }

    public void SetActiveYellowHieloLimaC()
    {
        _yellowHieloLimaC.SetActive(true);
    }

    public void SetActiveOrangeHieloLimaC()
    {
        _orangeHieloLimaC.SetActive(true);
    }

    public void SetActiveGreenHieloLimaC()
    {
        _greenHieloLimaC.SetActive(true);
    }

    public void SetActivePurpleHieloLimaC()
    {
        _purpleHieloLimaC.SetActive(true);
    }


}
