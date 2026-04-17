using BNG;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] Transform _UIPos;
    BNGPlayerController player;
    Vector3 pos;

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
}
