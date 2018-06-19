using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void Start()
    {
        transform.position = target.position - new Vector3(0,0,10);
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
