using UnityEngine;

public class NewDialogue : MonoBehaviour
{
    int index = 2;
    private void Update()
    {
          if(Input.GetMouseButtonDown(0) && transform.childCount > 1)
          {
            if(PlayerMovement.dialogue)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index += 1;
                if(transform.childCount == index)
                {
                    index = 2;
                    PlayerMovement.dialogue = false;
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
          }
    }
}
