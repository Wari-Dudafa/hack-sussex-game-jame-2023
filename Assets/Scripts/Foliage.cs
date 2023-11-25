using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foliage : MonoBehaviour
{
    public SpriteRenderer sprite;
    public bool shouldFlip;

    void Start()
    {
        shouldFlip = (Random.Range(0, 2) == 0);
        sprite = GetComponent<SpriteRenderer>();

        if (shouldFlip)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }
}
