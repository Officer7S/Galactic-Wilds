using UnityEngine;  
  
public class NewMonoBehaviourScript : MonoBehaviour  
{  
    public Dialogue dialogue;  
    public bool playerInRange;  
  
    void Update()  
    {  
        if (playerInRange && Input.GetKeyDown(KeyCode.F))  
        {  
            TriggerDialogue();  
        }  
    }  
  
    public void TriggerDialogue()  
    {  
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);  
    }  
  
    // 3D Trigger functions  
    void OnTriggerEnter(Collider other)  
    {  
        if (other.CompareTag("Player"))  
        {  
            playerInRange = true;  
        }  
    }  
  
    void OnTriggerExit(Collider other)  
    {  
        if (other.CompareTag("Player"))  
        {  
            playerInRange = false;  
        }  
    }  
}  
