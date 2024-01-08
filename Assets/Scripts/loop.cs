using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loop : MonoBehaviour
{
    [SerializeField]
    Transform exit;

    void OnTriggerEnter(Collider col)
    {
        gameManager.instance.loop(exit.position + (col.transform.position - transform.position));
    }
}
