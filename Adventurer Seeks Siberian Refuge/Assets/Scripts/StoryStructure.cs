using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StoryStructure : MonoBehaviour {

    // updates the story page. called by buttons and other "progress" keys
	
	public static StoryStructure instance = null;

    static int totalPages;                  		// total pages in current level
    public static int currentPage;                 // currently displayed page

    public GameObject activeText;                  // element that displays the current story
	string supplies;
	
	// buttons and sundry
	public GameObject headerText;
	public GameObject continueButton;
	public GameObject choice1Button;
	public GameObject choice1Text;
	public GameObject choice2Button;
	public GameObject choice2Text;
	
	public GameObject pageState;

	void Start()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
		
		currentPage = pageState.GetComponent<PageState>().currentPage;	

		totalPages = 23;		
		
		UpdateStoryPanel();
	}

    public void UpdateStoryPanel()
    {
        // add each dialogue option in a case below. additional cases are easily added. 
        // use the format described in case 1
        switch (currentPage)
        {
            case 1:
				headerText.GetComponent<Text>().text = "Pilot:";
                activeText.GetComponent<Text>().text = "\"The helicopter is going down! Brace for impact!\"";
                break;
            case 2:
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "Your helicopter clips a tree, and plummets into the Siberian Wilderness. The helo explodes in a cacaphonous cloud of flame and debris. Your body is thrown away from the helicopter with the force of the crash";
                break;
			case 3:				
				headerText.GetComponent<Text>().text = "Adventurer:";
                activeText.GetComponent<Text>().text = "\"I say! It appears we've landed ourselves in a bit of a quagmire!\"";
				break;
			case 4:				
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "Peering through the wreckage as you pick yourself up, you hear the tortured screams of your pilot, trapped in the twisted steel. \n\nAs you approach the wreck to try and save him, the reserve fuel canisters catch fire, and the explosion knocks you back to the treeline.";
				break;
			case 5:				
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "As the roar of the fire drowns out all sound, you realize that, tragically, there's no hope of saving him.";
				break;
			case 6:				
				headerText.GetComponent<Text>().text = "Adventurer:";
                activeText.GetComponent<Text>().text = "\"I was the only survivor. No food, no shelter, stranded here in the Siberian wild. Let's see if I can get my bearings.\"";
				break;
			case 7:
				headerText.GetComponent<Text>().text = "";
				activeText.GetComponent<Text>().text = "After following a game trail for what seems to be an hour or so, you come to a fork in the road.";
				break;
			case 8:
				headerText.GetComponent<Text>().text = "";
				activeText.GetComponent<Text>().text = "You can: \n\n1 - Head deeper into the forest to gather supplies.\n2 - Hike to a rocky outcropping in the hopes of finding shelter.";
				choice1Button.SetActive(true);
				choice2Button.SetActive(true);
				continueButton.SetActive(false);
				break;				
			case 9:				// option 1
				headerText.GetComponent<Text>().text = "";
				activeText.GetComponent<Text>().text = "You decide to continue into the forest. You come to a clearing, and your instincts tell you there may be supplies nearby, but you are wary of being out in the open for too long.";
				currentPage++;
				supplies = "cobble together a makeshift spear from a particularly large branch.";
				break;				
			case 10:			// option 2
				headerText.GetComponent<Text>().text = "";
				activeText.GetComponent<Text>().text = "The path to the outcropping brings you back closer to the crash site. In the bitter cold, it seems as if the flames have died down. There might be something worth salvaging within the wreckage.";
                supplies = "find some metal plating from the wreckage.";
				break;
            case 11:		
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "Do you:\n\n1 - Choose to gather supplies\n2 - Continue to seek shelter";
                choice1Button.SetActive(true);
				choice2Button.SetActive(true);
				continueButton.SetActive(false);
				break;
            case 12:			// option 1	
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "You manage to " + supplies + " This will come in handy, if you ever need to defend yourself.";
                currentPage++;
				break;
            case 13:			// option 2	
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "Despite the opportunity for help, you think there's an equally likely chance for you to get seriously hurt.";
                break;
            case 14:			
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "You cross the clearing and resume your trek through the darkening woods.";
                break;				
            case 15:			
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "As the dim sun begins to sink down below the horizon, you find yourself on the edge of a vast expanse of snow. If you squint just right, you can barely make out a structure off in the distance.";
                break;
			case 16:			
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "You trudge across the plain in the dying twilight, making ponderous but steady progress.";
                break;				
			case 17:			
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "*CRACK*";
                break;				
			case 18:			
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "Without warning, the ice shelf beneath you collapses, and you are thrown head over heels into a yawning crevasse.";
                break;				
			case 19:			
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "The dust settles with a resounding *WHUMPF*, and you stand, miraculously uninjured, at the bottom of the pit.";
                break;
			case 20:			
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "You begin the laborious task of climbing out of this forsaken crack, hopefully before you lose the last light of day.";
                break;
			case 21:
				currentPage++;
				pageState.GetComponent<PageState>().currentPage = currentPage;
				SceneManager.LoadScene(2);
				break;
			case 22:			
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "You did it. You survived the pit. Tattered and beaten, you shamble your way over to the outpost. With luck, you can barter passage back to civilization.";
                break;
			default:		
				headerText.GetComponent<Text>().text = "";
                activeText.GetComponent<Text>().text = "";
				SceneManager.LoadScene(0);
				break;
        }
    }
	
	public void ClickContinue()
	{
		if (currentPage < totalPages)
		{
			currentPage++;
			UpdateStoryPanel();
		}
		else
			SceneManager.LoadScene(0);
		
	}
	
	public void ClickOption1()
	{
		currentPage++;
		UpdateStoryPanel();
		choice1Button.SetActive(false);
		choice2Button.SetActive(false);
		continueButton.SetActive(true);
	}
	
	public void ClickOption2()
	{
		currentPage++;
		UpdateStoryPanel();
		choice1Button.SetActive(false);
		choice2Button.SetActive(false);
		continueButton.SetActive(true);
	}
}
