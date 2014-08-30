using UnityEngine;
using System.Collections;

public interface SFXObject {

	void play();

	void play(bool newInstance);

	void stop();

	void pause();
	
}
