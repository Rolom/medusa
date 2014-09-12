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
		phrasesList.Add("A jelly fish is 96% water... \n and 100% deepness.");
		phrasesList.Add("Sometimes, you just have \n to let it go... and flow.");
		phrasesList.Add("Can be the soul \n so deep?.");
		phrasesList.Add("Your mind and body are only\n an illusion that hide the truth.");
		phrasesList.Add("Stop Thinking, \n Start experiencing.");
		phrasesList.Add ("Just deepness \n will set you free.");
		phrasesList.Add ("Look around you,\n you are not alone.");
		phrasesList.Add ("Let me show you something... \n I just did.");
		phrasesList.Add ("There is a space \n between the spaces");
		phrasesList.Add ("Deep in your soul, you know \n the answer to the \n question... that drives us.");
		phrasesList.Add ("If you keep trying, \n then you already have lost. Just \n feel the experience and continue.");
		phrasesList.Add ("If you try to win, \n then you will lose. So you \n don’t try, just let it go.");
		phrasesList.Add ("There is a deep and simple \n mining in the life... but that \n is hidden from our senses.");
		phrasesList.Add ("Maybe the entire ocean \n is moving... and you are \n just standing there.");
		phrasesList.Add ("The jelly fishes are \n beautiful... and so are you?.");
		phrasesList.Add ("The jelly fishes are \n just a mirror... of your soul.");
		phrasesList.Add ("This is beautiful... \n thanks for share it with me.");
		phrasesList.Add ("Jelly fishes are 96% \n water... and 100% deepness.");
		phrasesList.Add ("In the deep, your soul \n might be a surface of emotions \n and jelly fishes floating.");
		phrasesList.Add ("Remember to forget.");
		phrasesList.Add ("Why do you want to fly\n  when you can swim?.");
		phrasesList.Add ("Why do you like this jellyfish? \n Does it reflects your soul?.");
		phrasesList.Add ("Let yourself go, \n so you can go deeper.");
		phrasesList.Add ("Is the plankton less \n valuable than the jellyfish?.");
		phrasesList.Add ("Maybe the jellyfish \n is scared of you?.");
		phrasesList.Add ("Can you feel the sound \n of the last whisper?.");
		phrasesList.Add ("Really, you don't have \n something more important \n to do... just breathe.");
		phrasesList.Add ("Why are you go so fast?... \n just enjoy the ride \n in to the unknown.");
		phrasesList.Add ("Can you look inside  \nyour eyes to really see?.");
		phrasesList.Add ("Go to depth, but \n not so far to lose yourself.");
		phrasesList.Add ("Do you know how much \n deep you can go?.");
		phrasesList.Add ("The sound of the depth \n is not so beautiful.");
		phrasesList.Add ("The sound of the depth \n can be so beautiful... \n like you are.");
		phrasesList.Add ("Your mind is brilliant!.");
		phrasesList.Add ("The nature knows how really \n you are, it created you.");
		phrasesList.Add ("Here you can hide \n the secrets of your soul.");
		phrasesList.Add ("What else can you \n find in the deeps?.");
		phrasesList.Add ("Did you hear the sound \n scale of the life?... \n open your eyes.");
		phrasesList.Add ("Deep down, you can \n find the unknown.");
		phrasesList.Add ("Falling deep is good \n to get up higher \n in your selfness.");
		phrasesList.Add ("Jellyfishes are beutiful, \n like you.");
		phrasesList.Add ("How much deeper would be \n the ocean without Jellyfishes?.");
		phrasesList.Add ("If you were a jellyfish, \n Would you be caught \n by Bob SquarePants?.");
		phrasesList.Add ("The irony of life is... \n we have to fight for peace.");
		phrasesList.Add ("The cry of a jellyfish does \n not mean weakness, means \n their feelings are true.");

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