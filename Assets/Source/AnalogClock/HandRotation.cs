using UnityEngine;

public class HandRotation : MonoBehaviour
{
    private Vector3 mousePosition;
    private float _angleToLookAtMouse = 90;

    void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Euler(0f, 0f, -rotation_z + _angleToLookAtMouse);
    }
}