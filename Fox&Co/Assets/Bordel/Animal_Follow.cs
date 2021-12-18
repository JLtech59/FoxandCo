using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using Mirror;

public class Animal_Follow : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent nma;
    private Animator mAnim;
    public float searchdist;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        nma = GetComponent<NavMeshAgent>();
        mAnim = GetComponent<Animator>();
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        mAnim.SetBool("isSitting", true);
        mAnim.SetBool("isRunning", false);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance > searchdist)
        {
            nma.SetDestination(target.transform.position);
            mAnim.SetBool("isSitting", false);
            mAnim.SetBool("isRunning", true);
        }
        else
        {
            mAnim.SetBool("isSitting", true);
            mAnim.SetBool("isRunning", false);
        }
        if (target != null)
        {
            DestroyImmediate(this);
        }
    }
    
    

}
