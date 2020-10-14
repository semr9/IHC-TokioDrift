using UnityEngine;

public class RotateOnAxis : MonoBehaviour
{
    [Tooltip("Applies a rotation of eulerAngles.z degrees around the z-axis, eulerAngles.x degrees around the x-axis, and eulerAngles.y degrees around the y-axis (in that order).")]
    public Vector3 rotationSpeed;
    public bool rotate;

    void Start()
    {
        rotate = true;
    }

    void Update()
    {
        if (rotate)
        {
            if (rotationSpeed.x != 0.0f && (transform.rotation.x >= 0.5f || transform.rotation.x <= -0.5f))
                rotationSpeed.x = -rotationSpeed.x;
            transform.Rotate(rotationSpeed);
        }
    }
}
