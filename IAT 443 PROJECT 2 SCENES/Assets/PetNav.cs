using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetNav : MonoBehaviour
{
    // Start is called before the first frame update

    public NavMeshAgent thisNav;
    public GameObject goal, start;

    public ReceiveOsc oscReciever;

    public GameObject floor;

    float minBound, maxBound, floorHeight, floorMiddle, floorXSize, floorZSize, minZBound;

    public float minMoveDist=0.1f;
    float currPos;

    public float maxHeight;

    public AudioClip walkSound;
    AudioSource thisSource;

    void Start()
    {
        thisSource.GetComponent<AudioSource>();
        thisNav.SetDestination(goal.transform.position);
        floorHeight = floor.transform.position.y;
        floorMiddle = floor.transform.position.z;

        //bounds would be middle position, +/- half of x size in each direction
        //wait also you could just do minBound + (x*size)

        float x = floor.transform.position.x;
        float maxSize = floor.GetComponent<Renderer>().bounds.extents.x;
        minBound = x - (maxSize / 2);
        maxBound = x + (maxSize / 2);
         
        floorZSize = floor.GetComponent<Renderer>().bounds.extents.z;
        float z = floor.transform .position.z;
        minZBound = z - (floorZSize / 2);

        floorXSize = maxSize;
        currPos = 0.9f;
    }

    [ContextMenu("reset")]
    void resetPos()
    {
        transform.position = start.transform.position;
        thisNav.SetDestination(goal.transform.position);
    }


    // Update is called once per frame
    void Update()
    {
        setTarget();
    }

    [ContextMenu("set target")]
    public void setTarget()
    {
        float xTemp = oscReciever.getX();
        if(Mathf.Abs(xTemp-currPos) > minMoveDist) {
            currPos = xTemp;

            float yTemp = floorHeight + (Random.Range(0.0f, 1.0f) * maxHeight);
            Debug.Log(yTemp);
            Vector3 position = new Vector3(0, yTemp, minZBound+(floorZSize*Random.Range(0.0f,1.0f)));
            position.x = minBound + (xTemp * floorXSize);
            thisNav.SetDestination(position);
            //add some random variable here for uhh z pos
        }

       
    }

    public void nextWalk()
    {
        //every time a SPRITE CHANGES DURING A WALK ANIM, there should be a SOUND THAT PLAYS
        //

        //Change sprite to next pose
        thisSource.PlayOneShot(walkSound);
        Debug.Log("sound triggered");

        //play sound


    }

    private void OnCollisionEnter(Collision collision)
    {

        WalkObj thisWalk = collision.gameObject.GetComponent<WalkObj>();
        if(thisWalk != null)
        {

            thisWalk.jumpedOn(transform.position);
            //play clip at current position

        }
        



        //find stepped on object
        //stepped on objects should have an associated audioclip
        //it should play the associated audio clip from that object, *at that source* - it'd be weird
        //if the sound moved with it




    }

}
