using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handLight : MonoBehaviour
{
    void Update()
    {
        this.transform.rotation = Quaternion.Lerp(
            this.transform.rotation,
            Camera.main.transform.rotation,
            20f * Time.deltaTime
        );
    }
}
