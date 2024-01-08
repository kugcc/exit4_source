using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fGameStarter : MonoBehaviour
{
    void OnTriggerEnter()
    {
        if (!gameManager.instance.isFGame)
            gameManager.instance.generateNewPassage();
    }
}
