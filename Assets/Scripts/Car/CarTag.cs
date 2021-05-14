using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class CarTag : MonoBehaviour
{
    public GameObject explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        // TODO: Insert collision code :)
        
        // One example for you, please follow this example making other collisions
        if (collision.gameObject.CompareTag("TeamTrees"))
        {
            Debug.LogError("Death");
            explode();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.LogError("Death");
            explode();
        }
        // Do not delete the section below - this is to guide you
        else if (collision.gameObject.CompareTag("Untagged"))
        {
            Debug.LogError("Undefined Object hit - please set the Tag");
        }
    }

    void explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Camera.main.transform.parent = null;
        Destroy(gameObject);
    }

}
