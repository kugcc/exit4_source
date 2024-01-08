using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceilingLight : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void hit()
    {
        audioSource.PlayOneShot(audioClip);

        Destroy(transform.GetChild(0).gameObject);
    }
}
