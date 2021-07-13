using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    
    public float radius = 3f;

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public bool destroyOnInteract;


    public virtual void OnInteract()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, radius);


    }

    void Update()
    {
        if (isInRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();

                if(destroyOnInteract)
                    Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            isInRange = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            isInRange = false;
        }
    }
}
