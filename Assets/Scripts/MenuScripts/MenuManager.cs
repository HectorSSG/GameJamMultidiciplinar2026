using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
    public void StartCinematic()
    {
        SceneManager.LoadScene("Video");
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Se Cerró el juego");
    }
    // public void ResetGame()
   //{
   //    PlayerPrefs.DeleteAll();
   //    foreach(GameObject obj in FindObjectsByType<GameObject>(FindObjectsSortMode.None))
   //    {
   //        if (obj.transform.parent == null)
   //        {
   //            Destroy(obj);
   //        }
   //    }
   //    SceneManager.LoadScene(0);
   //}
}