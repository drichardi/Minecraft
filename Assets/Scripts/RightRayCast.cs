using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class RightRayCast : MonoBehaviour
{
    public Landscape landscape;

    public int hitDamage = 2;

    RaycastHit hit = new RaycastHit();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bool didHit = Physics.Raycast(transform.position, transform.forward, out hit, 100);

        if (didHit)
        {
            //Debug.Log(hit.transform + " " + hit.distance);
            
            Debug.DrawRay(transform.position, transform.forward * 100, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
        }

        if (Input.GetMouseButtonUp(0) && didHit && hit.distance < 4)
        {

          
            Block block = hit.transform.gameObject.GetComponent<Block>();

            if (block)
            {
                block.ChangeHealth(-hitDamage);

                Debug.Log("Applied " + hitDamage + " to block. Block has " + block.currentHealth + " remaining health.");
            }
            
            

           

            
        }
    }
}
