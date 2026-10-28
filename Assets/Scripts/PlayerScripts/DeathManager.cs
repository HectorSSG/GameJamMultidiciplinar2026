using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public bool isDeath = false;
    [SerializeField] private GameObject deathPanel;

    public void Start()
    {
        deathPanel.SetActive(false);
    }

    public void Update()
    {
        if (isDeath == true)
        {
            Time.timeScale = 0f;
            deathPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            deathPanel.SetActive(false);
        }
    }

}
