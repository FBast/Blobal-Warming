using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingSound : MonoBehaviour
{

    private SoundComponent sc;
    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SoundComponent>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        sc.Play("Land");
    }
}
