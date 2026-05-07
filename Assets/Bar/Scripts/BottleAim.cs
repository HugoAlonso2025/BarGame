using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class BottleAim : MonoBehaviour
{
    [SerializeField] GameObject liquidPrefab;
    ParticleSystem particles;
    [SerializeField] Transform _waterPos;
    [SerializeField] LayerMask glassLayer;
    Rigidbody rb;

    AudioSource source;
    [SerializeField] AudioClip waterEarlySound;
    [SerializeField] AudioClip waterSound;

    SoundManager sound;

    bool onWaterGO;
    bool isGoing;

    GameObject liquidGO;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (transform.localEulerAngles.z > 90 && transform.localEulerAngles.z < 270 && rb.collisionDetectionMode == CollisionDetectionMode.ContinuousDynamic)
        {
            if (liquidGO == null)
            {
                liquidGO = Instantiate(liquidPrefab, _waterPos.position, _waterPos.rotation, transform);
                particles = liquidGO.GetComponent<ParticleSystem>();
            }
            else
            {
                particles.Play();
                if (!onWaterGO)
                {
                    StartCoroutine(WaterSound());
                }
            }
        }
        else
        {
            if (liquidGO != null)
            {
                particles.Stop();
                isGoing = false;
                onWaterGO = false;
                source.Stop();
            }
        }
    }

    void DoSound(AudioClip sound)
    {
        float random;
        random = Random.Range(0.8f, 1.2f);
        source.pitch = random;
        source.PlayOneShot(sound);
    }

    IEnumerator WaterSound()
    {
        if (!isGoing)
        {
            onWaterGO = true;
            DoSound(waterEarlySound);
            yield return new WaitForSeconds(4);
            isGoing = true;
            onWaterGO = false;
        }
        else
        {

            onWaterGO = true;
            DoSound(waterSound);
            yield return new WaitForSeconds(7);
            onWaterGO = false;
        }

    }
}
