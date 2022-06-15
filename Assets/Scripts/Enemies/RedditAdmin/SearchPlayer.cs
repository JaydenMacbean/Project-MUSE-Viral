using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour
{
    RA_Manager PLocator;
    [SerializeField] private LayerMask detectionLayer;
    [SerializeField] public Player mainTarget;
    public GameObject P1;

    
    private void Awake()
    {
        PLocator = GetComponent<RA_Manager>();
        P1 = GameObject.Find("Player");
    }

    private void Update()
    {
        
    }

    public void HandleDetection()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, PLocator.detectionRadius, detectionLayer);
        
        for(int i = 0; i < colliders.Length; i++)
        {
            Player p1 = colliders[i].transform.GetComponent<Player>();
            if(p1 != null)
            {
                Vector3 targetDirection = p1.transform.position - transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                if(viewableAngle > PLocator.minimumDAngle && viewableAngle < PLocator.maximumDAngle)
                {
                    mainTarget = p1;
                    Debug.Log("Player found");
                }
            }             
        }
    }
}
