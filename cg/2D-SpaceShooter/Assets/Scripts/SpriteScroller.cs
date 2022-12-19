using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 speed;
    Vector2 offset;
    Material material;
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    private void Update()
    {
        offset = speed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
