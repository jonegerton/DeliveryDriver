using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField]Color32 hasPackageTint = new Color32(255,255,0, 255);
    [SerializeField]Color32 noPackageTint = new Color32(255,0,255,255);

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageTint;
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log($"Delivery.OnCollisionEnter2D: {other.gameObject.name}");
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log($"Delivery.OnTriggerEnter2D: {other.gameObject.name}");

        if (other.tag == "Package" && !hasPackage) {
            hasPackage = true;
            Debug.Log("Package collected");
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageTint;
        }
        
        if (other.tag == "Customer" && hasPackage) {
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageTint;
        }
    }
}