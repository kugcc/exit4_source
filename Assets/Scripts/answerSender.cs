using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerSender : MonoBehaviour
{
    [SerializeField] bool ans;

    void OnTriggerEnter(Collider col)
    {
        if (gameManager.instance.isFGame)
            gameManager.instance.answer(ans,col.transform.position - transform.position);
    }
}