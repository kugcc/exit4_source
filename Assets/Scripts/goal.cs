using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    [SerializeField]
    float effectDistance;

    //エフェクトを先行して表示する距離
    [SerializeField]
    float effectForwardness;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        float playerDistance =
            Vector3.Distance(
                this.transform.position,
                gameManager.instance.player.transform.position
            ) - effectForwardness;
        if (playerDistance < effectDistance)
        {
            screenEffect.instance.drawPannel(1f - (playerDistance / effectDistance), Color.white);
            if (playerDistance <= 0f)
            {
                scm.Endroll();
            }
        }
    }
}
