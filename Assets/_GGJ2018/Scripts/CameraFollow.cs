using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private float interpVelocity;
    public float CameraSnapSpeed = 5.0f;
    public GameObject target;
    public GameObject target2;
    public Vector3 offset;
    Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {            
            float distance = Vector3.Distance(target.transform.position, target2.transform.position);
            float orthoSize = Mathf.Clamp(distance, 5, 10);
            orthoSize = Mathf.Lerp(Camera.main.orthographicSize, orthoSize, 0.005f);
            Camera.main.orthographicSize = orthoSize;

            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            // Weighted towards target1
            Vector3 look = Vector3.Lerp(target.transform.position, target2.transform.position, 0.7f);
            Vector3 targetDirection = (look - posNoZ);

            interpVelocity = targetDirection.magnitude * CameraSnapSpeed;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}