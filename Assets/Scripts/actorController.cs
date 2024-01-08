using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actorController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float runSpeed;

    [SerializeField]
    float rotSpeed;

    public Vector3 velocity;
    public float rotInput;

    [SerializeField]
    float footStepSoundDuration = 0.5f;
    float distance2Sound = 0.5f;

    public bool isRunning = false;

    [SerializeField] bool isPlayer;
    public bool isP
    {
        get { return isPlayer; }
    }

    [SerializeField]
    AudioClip[] footSteps;

    AudioSource audioSource;
    Quaternion charaRotate = Quaternion.identity;

    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        distance2Sound = footStepSoundDuration;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        moveActor();
        rotateActor();
    }

    public void teleport(Vector3 pos, float deg)
    {
        characterController.enabled = false;

        transform.position = pos;
        transform.localRotation *= Quaternion.Euler(0f, deg, 0f);
        charaRotate *= Quaternion.Euler(0f, deg, 0f);
        characterController.enabled = true;
    }

    public void catched()
    {
        characterController.enabled = false;
    }

    void moveActor()
    {
        float speed = (isRunning == true) ? runSpeed : moveSpeed;
        Vector3 velc =
            (transform.forward * velocity.z + transform.right * velocity.x).normalized * speed;
        distance2Sound -= (velc * Time.deltaTime).magnitude;

        if (distance2Sound <= 0)
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.PlayOneShot(footSteps[Random.Range(0, footSteps.Length)]);
            distance2Sound = footStepSoundDuration;
        }
        
        if (!characterController.isGrounded)
        {
            velc += Physics.gravity;
        }
        characterController.Move(velc * Time.deltaTime);

    }

    void rotateActor()
    {
        //　横の回転値を計算
        charaRotate *= Quaternion.Euler(0f, rotInput, 0f);

        //　キャラクターの回転を実行
        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            charaRotate,
            rotSpeed * Time.deltaTime
        );
    }
}
