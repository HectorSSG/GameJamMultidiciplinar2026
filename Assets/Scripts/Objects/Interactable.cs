using UnityEngine;
using UnityEngine.SceneManagement;
public class Interactable : MonoBehaviour
{
    public void ActiveObject()
    {
        Debug.Log("Raycast leído" + gameObject.name);
        ChangeScene();
    }
    public void ChangeScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Additive);
        }
        else
        {
            Debug.LogWarning("No hay más escenas en el Build");
        }
    }
}
