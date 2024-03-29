﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class CarTag : MonoBehaviour
{
    public GameObject explosionEffect;

    //Used in Canvas manager to know, when to enable DndGamePanel
    public bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("TeamTrees") || other.CompareTag("Wall") || other.CompareTag("Obstacle"))
        {
            if(other.CompareTag("Obstacle"))
            {
                other.GetComponent<Animator>().SetBool("hasCollided", true);
            }
            explode();
            hasCollided = true;
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
