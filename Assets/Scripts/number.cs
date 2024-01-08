using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class number : MonoBehaviour
{
    TextMeshPro tMPro;

    // Start is called before the first frame update
    void Start()
    {
        tMPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        tMPro.text = Mathf
            .Clamp(gameManager.instance.curLoc, 0, gameManager.instance.goalLoc)
            .ToString();
    }
}
