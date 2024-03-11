using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);
    [SerializeField] float delay = 100000.00f; 
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("OUCH!!!");
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage){
            Debug.Log("Package picked up.");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, delay);
        }
        if(other.tag == "End" && hasPackage){
            Debug.Log("The package is delivered.");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
