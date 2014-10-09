using UnityEngine;
using System.Collections;

public class EndMenu : BasicGUI {

	private ArrayList phrasesList;
	private string currentPhrace;
	public GameObject highScoreParticles;
	public bool particleFlag=false;
	private float DOWN_POSITION=120;
	private float upReplayAnimation1=120;
	private float upMainMenuAnimation2=150;
	private float upVelocity=0.01f;

	public void addPhraces(){
		phrasesList=new ArrayList();
		phrasesList.Add("Sometimes, you just have \n to let it go... and flow. ");
		phrasesList.Add("Can the soul be  \n so deep? ");
		phrasesList.Add("Your mind and body are only \n an illusion that hides the truth. ");
		phrasesList.Add("Stop thinking, \n start experiencing. ");
		phrasesList.Add("Only deepness \n will set you free. ");
		phrasesList.Add("Look around,\n you are not alone. ");
		phrasesList.Add("There is space \n between spaces ");
		phrasesList.Add("Deep in your soul, you know \n the answer to the \n question... that drives you. ");
		phrasesList.Add("If you keep trying, \n then you have already lost. Just \n feel the experience and go on. ");
		phrasesList.Add("If you try to win, \n you will lose. So \n don’t try, just let it go. ");
		phrasesList.Add("There is a deep and simple \n meaning about life... but that \n is hidden from our senses. ");
		phrasesList.Add("Maybe the entire ocean \n is moving... and you are \n just standing there. ");
		phrasesList.Add("The jellyfish are \n beautiful... and so are you? ");
		phrasesList.Add("The jellyfish are \n just a mirror... of your soul. ");
		phrasesList.Add("This is beautiful... \n thanks for sharing it with me. ");
		phrasesList.Add("Jellyfish are 96% \n water... and 100% deepness. ");
		phrasesList.Add("In the deep, your soul \n might be a surface of emotions \n and jellyfish floating. ");
		phrasesList.Add("Remember to forget.");
		phrasesList.Add("Why do you want to fly \n when you can swim? ");
		phrasesList.Add("Why do you like this jellyfish? \n Does it reflect your soul? ");
		phrasesList.Add("Let yourself go, \n so you can go deeper. ");
		phrasesList.Add("Is the plankton less \n valuable than the jellyfish? ");
		phrasesList.Add("Maybe the jellyfish \n is scared of you? ");
		phrasesList.Add("Can you feel the sound \n of the last whisper? ");
		phrasesList.Add("There isn’t really \n anything more important for you \n ... just breathe. ");
		phrasesList.Add("Why are you going so fast...? \n Just enjoy the journey \n into the unknown. ");
		phrasesList.Add("Can you look inside \n your eyes to really see? ");
		phrasesList.Add("Go to the depth, but \n not so far to lose yourself. ");
		phrasesList.Add("Do you know how deep \n you can go? ");
		phrasesList.Add("The sound of the depth \n is not so beautiful. ");
		phrasesList.Add("The sound of the depth \n can be so beautiful... \n just like you. ");
		phrasesList.Add("Your mind is brilliant!. ");
		phrasesList.Add("Nature knows how deep you \n can be, it created you. ");
		phrasesList.Add("Here you can hide \n the secrets of your soul. ");
		phrasesList.Add("What else can you \n find in the deep? ");
		phrasesList.Add("Did you hear the sound \n scale of the life? ... \n open your eyes. ");
		phrasesList.Add("Deep down, you can \n find the unknown. ");
		phrasesList.Add("Falling deep is good \n in order to get up higher \n in your selfness. ");
		phrasesList.Add("Jellyfish are beautiful, \n just like you. ");
		phrasesList.Add("How much deeper would the ocean be \n without Jellyfish? ");
		phrasesList.Add("If you were a jellyfish, \n Would you be caught \n by Bob SquarePants? ");
		phrasesList.Add("The irony of life is... \n we have to fight for peace. ");
		phrasesList.Add("The cry of a jellyfish \n does not mean weakness,\n means that their feelings \n are true. ");

	}

	public void OnEnable(){
		if(phrasesList==null){
			addPhraces();
		}
		choosePhrase();
		particleFlag=false;
		upMainMenuAnimation2=150;
		upReplayAnimation1=DOWN_POSITION;
	}
	
	void OnGUI () {
		GUI.color=changeAlphaGui(GUI.color);

		GUI.skin=myGuiSkin;
		
		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(17);
		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(22);
		GUI.Box(RectAligment.centerRect(10,100,100),"Score "+ScoreManager.getInstance().getScore());
		
		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(12);
		if(ScoreManager.getInstance().getScore()!=Persistence.getInstance().getHighscore() && Persistence.getInstance().getHighscore() !=0){
			myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(12);
			GUI.Box(RectAligment.centerRect(25,100,100),"Best Score "+Persistence.getInstance().getHighscore());
		}else{
			GUI.Box(RectAligment.centerRect(25,100,100),"New Best Score!!!");
			if(!particleFlag){
				Instantiate(highScoreParticles);
				particleFlag=true;
			}
		}

		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(10);
		GUI.Box(RectAligment.centerRect(41,100,100),currentPhrace);

		showPLayAgainButton();

	}

	private void showPLayAgainButton(){

		if(upReplayAnimation1>69){
			upReplayAnimation1-=upVelocity*(upReplayAnimation1-69);
		}

		if(upMainMenuAnimation2>80){
			upMainMenuAnimation2-=upVelocity*(upMainMenuAnimation2-80);
		}

		if(GUI.Button(RectAligment.centerRect(upReplayAnimation1,100,15),"PLAY AGAIN")){
			GUIManager.getInstance().replayGame();
		}
		
		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(12);
		if(GUI.Button(RectAligment.centerRect(upMainMenuAnimation2,50,15),"Main Menu")){
			GUIManager.getInstance().showMainMenu();
		}
	}

	private void choosePhrase(){
		int randomPhraseSelector=Random.Range(0,phrasesList.Count);
		currentPhrace=""+phrasesList[randomPhraseSelector];
	}

}