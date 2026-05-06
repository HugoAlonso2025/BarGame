using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public LayerMask mask;
    public float radius;
    bool onActive = true;

    void Update()
    {
        if (Physics.CheckSphere(transform.position, radius, mask) && onActive)
        {
            SceneManager.LoadScene("Level");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
