using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryStructure : MonoBehaviour {

    // updates the story page. called by buttons and other "progress" keys

    static int totalPages;                  // total pages in current level
    static int currentPage;                 // currently displayed page

    public GameObject activeText;                  // element that displays the current story


    public void UpdateStoryPanel()
    {
        // add each dialogue option in a case below. additional cases are easily added. 
        // use the format described in case 1
        switch (currentPage)
        {
            case 1:
                activeText.GetComponent<Text>().text = "Put yer strings here.";
                break;
            case 2:

                break;
            default:
                break;
        }
    }

}
