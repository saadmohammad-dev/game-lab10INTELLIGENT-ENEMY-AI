using UnityEngine;
 
public class IndoorFollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 12f, -8f);
    public float smoothness = 8f;
    public float lookHeight = 1f;
 
    private void LateUpdate()
    {
        if (target == null) return;
 
        Vector3 desiredPosition = target.position + offset;
        float blend = 1f - Mathf.Exp(-smoothness * Time.deltaTime);
        transform.position = Vector3.Lerp(
            transform.position, desiredPosition, blend);
        transform.LookAt(target.position + Vector3.up * lookHeight);
    }
}