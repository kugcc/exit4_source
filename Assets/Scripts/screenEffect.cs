using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screenEffect : MonoBehaviour
{
    public static screenEffect instance;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    Image pannel;

    public void drawPannel(float transp, Color color)
    {
        pannel.color = color - new Color(0, 0, 0, 1f - (transp * transp));
    }
}
