using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public LayerMask mask;
    public float radius;
    bool onActive = true;
    [SerializeField] Transform pos;

    void Update()
    {
        if (Physics.CheckSphere(pos.position, radius, mask) && onActive)
        {
            SceneManager.LoadScene("Level");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos.position, radius);
    }
}
