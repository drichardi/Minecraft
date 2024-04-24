using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RightRayCast : MonoBehaviour
{
    public Landscape landscape;

    public int hitDamage = 2;
    bool useButtonHeld = false;
    public float interactDistance = 3.5f;

    RaycastHit hit = new RaycastHit();
    Coroutine interactingFunction;

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

        if (Input.GetMouseButton(0) && didHit)
        {
            if (!useButtonHeld && hit.distance < interactDistance)
            {
                useButtonHeld = true;
                interactingFunction = StartCoroutine(HitBlock());
            }
        }
        else
        {
            if (useButtonHeld)
            {
                useButtonHeld = false;
                StopCoroutine(interactingFunction);
            }
            
        }
    }

    // Waits .5 seconds (to ensure button is held down)
    // TODO Expand to general interactions for different block types
    // TODO Take into effect hardness of block - probably in Block.ChangeHealth
    IEnumerator HitBlock()
    {
        while (useButtonHeld)
        {
            yield return new WaitForSeconds(.5f);
            Block block;
            bool didHit = Physics.Raycast(transform.position, transform.forward, out hit, 100);

            if (didHit)
            {
                block = hit.transform.gameObject.GetComponent<Block>();

                if (block && hit.distance < interactDistance)
                {
                    block.ChangeHealth(-hitDamage);

                    Debug.Log("Applied " + hitDamage + " to block. Block has " + block.currentHealth + " remaining health.");
                }
            }  
        }
         
    }
}
