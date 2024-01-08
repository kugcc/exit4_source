using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField] float rotSpeed;

    float angleLimit = 89f;

    public float rotInput;
    Quaternion charaRotate = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //　一旦角度を計算する	
        charaRotate *= Quaternion.Euler(-rotInput, 0f, 0f);
        //　カメラのX軸の角度が限界角度を超えたら限界角度に設定
        transform.localRotation = Quaternion.Lerp(transform.localRotation, charaRotate, rotSpeed * Time.deltaTime);
        if (transform.localRotation.x > 0.7f)
        {
            transform.localRotation = Quaternion.Euler(angleLimit, 0f, 0f);
        }

        else if(transform.localRotation.x < -0.7f)
        {
            transform.localRotation = Quaternion.Euler(-angleLimit, 0f, 0f);
        }
    }
}
