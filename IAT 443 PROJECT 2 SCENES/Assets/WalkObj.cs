using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkObj : MonoBehaviour
{
    // Start is called before the first frame update


    public AudioClip landSound, walkSound;


    //randomize walkSound
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jumpedOn(Vector3 pos)
    {

        if(landSound != null)
        {
            AudioSource.PlayClipAtPoint(landSound, pos);
        }
    }
}
