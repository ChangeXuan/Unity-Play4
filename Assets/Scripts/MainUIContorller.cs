using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIContorller : MonoBehaviour {

	private static MainUIContorller _instance;
	public static MainUIContorller Instance {
		get {
			return _instance;
		}
	}

	public int score = 0;
	public int len = 0;
	public Text msgText;
	public Text scoreText;
	public Text lengthText;

	public Image pauseImage;
	public Sprite[] spriteButton;

	public bool isPause = false;

	void Awake() {
		_instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	public void UpdateUI(int s = 5,int l = 1) {
		score += s;
		len += l;
		scoreText.text = "得 分:\n" + score;
		lengthText.text = "长 度:\n" + len;
	}

	public void pause() {
		isPause = !isPause;
		if (isPause) {
			Time.timeScale = 0;
			pauseImage.sprite = spriteButton [0];
		} else {
			Time.timeScale = 1;
			pauseImage.sprite = spriteButton [1];
		}
	}

	public void home() {
		UnityEngine.SceneManagement.SceneManager.LoadScene (0);
	}

	public void startPlay() {
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}
}
