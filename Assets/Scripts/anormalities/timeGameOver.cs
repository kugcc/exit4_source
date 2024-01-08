using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeGameOver : MonoBehaviour
{
    [SerializeField]
    float duration;

    void Start()
    {
        Invoke("gameOver", duration);
    }

    void gameOver() {
        screenEffect.instance.drawPannel(1f, Color.black);
        StartCoroutine(scm.restartGame(2f));
    }
}
