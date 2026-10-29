using UnityEngine;

public class ActivationScript : MonoBehaviour
{
    public MonoBehaviour scriptToActive;
    public GameObject tutorialPanel;
    public GameObject panelObjetive;
    public float activationTime;
    private void Start()
    {
        if (scriptToActive != null)
        {
            scriptToActive.enabled = false;
            Invoke(nameof(OnScript), activationTime);
            Invoke(nameof(OffPanel), activationTime);
            Invoke(nameof(FindDoor), activationTime);
        }
    }
    public void OnScript()
    {
        if (scriptToActive != null)
        {
            scriptToActive.enabled = true;
        }
    }
    public void OffPanel()
    {
        if (tutorialPanel)
        {
            tutorialPanel?.SetActive(false);
        }
    }
    public void FindDoor()
    {
        if (panelObjetive)
            panelObjetive?.SetActive(true);
    }
}
