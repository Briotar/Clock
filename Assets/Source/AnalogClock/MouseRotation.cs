using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
