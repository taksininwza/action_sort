using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject followObject;
    private void LateUpdate()
    {
        transform.position = followObject.transform.position + new Vector3(0, 0, -10);
    }
}

