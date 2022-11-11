using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasItem = false;
    Color32 defaultColor;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Boommmmmm");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //11:40
        if (other.tag == "Item" && hasItem == false)
        {
            Color32 color = other.GetComponent<SpriteRenderer>().color;
            spriteRenderer.color = color;
            Destroy(other.gameObject, 0.05f);
            hasItem = true;
        }
        if (other.tag == "DropZone" && hasItem == true)
        {
            spriteRenderer.color = defaultColor;
            hasItem = false;
        }
    }
}
