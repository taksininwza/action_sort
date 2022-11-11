using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float speed = 50f;
    [SerializeField] float steering = -40f;
    [SerializeField] float extraSpeed = 1;
    void Update()
    {
        float currentSpeed = Input.GetAxis("Vertical") * speed * Time.deltaTime * extraSpeed;
        float currentSteering = Input.GetAxis("Horizontal") * steering * Time.deltaTime;
        transform.Rotate(0, 0, currentSteering);
        transform.Translate(0, currentSpeed, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.tag == "Item")
        // {
        //     extraSpeed = 50;
        // }
    }
}
