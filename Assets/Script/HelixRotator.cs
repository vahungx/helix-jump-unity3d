using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HelixRotator : MonoBehaviour
{
    public float rotationSpeed = 20f;
    public float roatationSpeedAndroid = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        #if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                float mouseX = Input.GetAxisRaw("Mouse X");
                //transform.Rotate (transform.position.x, -mouseX * rotationSpeed * Time.deltaTime, transform.position.z);
                transform.Rotate(0, -mouseX * rotationSpeed * Time.deltaTime, 0);
            }

        #elif UNITY_ANDROID

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                float xDeltaPos = Input.GetTouch(0).deltaPosition.x;
                transform.Rotate(0, -xDeltaPos * rotationSpeed * Time.deltaTime, 0);
            }
        #endif
    }
}
