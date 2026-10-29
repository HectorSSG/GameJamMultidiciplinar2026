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
        int lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No hay más escenas en el Build");
        }
        if (currentSceneIndex == lastSceneIndex)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
