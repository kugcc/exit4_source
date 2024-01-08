using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureWall : MonoBehaviour
{
    [SerializeField]
    float speed = 0f;

    [SerializeField]
    float accel = 1f;

    [SerializeField]
    float maxSpeed = 10f;

    [SerializeField]
    Vector3 direction = Vector3.forward;

    [SerializeField]
    float maxDistance;

    float distanceRan;
    bool playerCatched;

    [SerializeField]
    GameObject backWall;
    List<Transform> catchedObj = new List<Transform>();

    void Start()
    {
        distanceRan = maxDistance;
    }

    void OnTriggerEnter()
    {
        distanceRan = 0f;
        backWall.SetActive(true);
    }

    void Update()
    {
        if (distanceRan >= maxDistance)
        {
            return;
        }

        if (speed < maxSpeed)
        {
            speed += accel * Time.deltaTime;
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        }

        float delta = speed * Time.deltaTime;
        distanceRan += delta;
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, transform.localScale * 0.9f, direction, out hit, Quaternion.identity, delta))
        {
            actorController aCon = hit.transform.gameObject.GetComponent<actorController>();
            hit.transform.SendMessage("hit", SendMessageOptions.DontRequireReceiver);
            if (aCon)
            {
                aCon.catched();
                catchedObj.Add(hit.transform);
                if (aCon.isP)
                {
                    playerCatched = true;
                }
            }
        }

        if (playerCatched && distanceRan >= maxDistance - 1.5f)
        {
            gameOver();
            return;
        }

        transform.position += direction * delta;
        foreach (Transform obj in catchedObj)
        {
            obj.position += direction * delta;
        }
    }


    void gameOver()
    {
        screenEffect.instance.drawPannel(1f, Color.black);
        StartCoroutine(scm.restartGame(1f));
    }
}
