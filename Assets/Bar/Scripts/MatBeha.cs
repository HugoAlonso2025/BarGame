using UnityEngine;

public class MatBeha : MonoBehaviour
{
    [SerializeField] float value;
    Renderer rend;
    void Start()
    {
        value = -0.5f;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.SetFloat("_FillAmount", value);
    }
}
