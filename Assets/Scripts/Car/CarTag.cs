using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class CarTag : MonoBehaviour
{
    public GameObject explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("TeamTrees"))
        {
            explode();
        }
        else if (other.CompareTag("Obstacle"))
        {
            other.GetComponent<Animator>().SetBool("hasCollided", true);
            explode();
        }
        else if (other.CompareTag("Wall"))
        {
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
