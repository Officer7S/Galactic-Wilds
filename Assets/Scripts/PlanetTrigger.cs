using UnityEngine;  
using UnityEngine.SceneManagement;  
  
public class PlanetTrigger : MonoBehaviour  
{  
    public string nextSceneName;  
  
    private void OnTriggerEnter(Collider other)  
    {  
        if (other.CompareTag("Planet"))  
        {  
            SceneManager.LoadScene(nextSceneName);  
        }  
    }  
}  
