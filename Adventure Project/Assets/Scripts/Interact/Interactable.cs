using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    public Transform interactionTransform;

    GameObject player;

    public bool hasInteracted = false;

    private void Start()
    {
        player = GameObject.Find("PlayerCharacter");
    }

    private void Update()
    {

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
        Debug.Log("You haven't set the interaction, stupid!");
    }



}
