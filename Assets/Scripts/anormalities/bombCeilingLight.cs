using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombCeilingLight : MonoBehaviour
{
    void OnTriggerEnter()
    {
        SendMessage("hit", SendMessageOptions.DontRequireReceiver);
    }
}
