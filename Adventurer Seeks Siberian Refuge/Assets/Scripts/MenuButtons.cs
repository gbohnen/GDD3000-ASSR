using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuButtons : MonoBehaviour {

    public GameObject buttonPanel;
    public GameObject creditsPanel;
    public bool creditsActive = false;

	// click level
    public void OnClickLevelButton()
    {
        SceneManager.LoadScene(1);
    }

    // click credits
    public void OnClickCreditsButton()
    {
        if (!creditsActive)
        {
            buttonPanel.GetComponent<CanvasGroup>().alpha = 0;
            buttonPanel.GetComponent<CanvasGroup>().interactable = false;
            buttonPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            creditsPanel.GetComponent<CanvasGroup>().alpha = 1;
            creditsPanel.GetComponent<CanvasGroup>().interactable = true;
            creditsPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;

            creditsActive = !creditsActive;
        }
        else
        {
            buttonPanel.GetComponent<CanvasGroup>().alpha = 1;            
            buttonPanel.GetComponent<CanvasGroup>().interactable = true;
            buttonPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
            creditsPanel.GetComponent<CanvasGroup>().alpha = 0;
            creditsPanel.GetComponent<CanvasGroup>().interactable = false;
            creditsPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

            creditsActive = !creditsActive;
        }        
    }

    // click exit
    public void OnClickExitButton()
    {
        Application.Quit();
    }
}
