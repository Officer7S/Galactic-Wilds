using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canva;
    bool player_detection = false;

    // Update is called once per frame
    void Update()
    {
        if(player_detection && Input.GetKeyDown(KeyCode.F) && !PlayerMovement.dialogue)
        {
            canva.SetActive(true);
            PlayerMovement.dialogue = true;
            NewDialogue("Hello");
            NewDialogue("Hi");
            NewDialogue("Hllo");
            NewDialogue("H");
            canva.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template,d_template.transform);
        template_clone.transform.parent = canva.transform;  
        template_clone.transform.localPosition = Vector3.zero;  
        template_clone.transform.localScale = Vector3.one;  

        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            player_detection = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        player_detection = false;
    }
}
