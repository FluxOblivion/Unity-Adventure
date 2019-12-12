using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    public Transform interactionTransform;

    public GameObject player;

    public bool hasInteracted = false;

    private void Update()
    {
        //float distance = Vector3.Distance();
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

    }

        public virtual void Interact()
    {
        //Interaction action goes here
    }



}
