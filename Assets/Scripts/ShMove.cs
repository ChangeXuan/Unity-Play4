using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShMove : MonoBehaviour {

	public int step;
	public float speed = 0.2f;

	private int x;
	private int y;
	private Vector3 headPoint;

	void Start() {
		InvokeRepeating ("move", 0, speed);
		x = 0;y = step;
	}

	void Update() {
		checkInput ();
		//move ();
	}

	void move() {
		headPoint = gameObject.transform.localPosition;
//		Vector3 newHead = new Vector3 (headPoint.x+x,headPoint.y+y,headPoint.z);
//		gameObject.transform.localPosition = Vector3.Lerp (headPoint, newHead, Time.deltaTime);
		gameObject.transform.localPosition = new Vector3 (headPoint.x+x,headPoint.y+y,headPoint.z);

		FoodMaker.Instance.pushBody (headPoint);
	}

	void checkInput() {
		if (MainUIContorller.Instance.isPause) {
			return;
		}
		if (Input.GetKey (KeyCode.W) && y != -step) {
			gameObject.transform.localRotation = Quaternion.Euler (0, 0, 0);
			x = 0;
			y = step;
		}
		if (Input.GetKey (KeyCode.S) && y != step) {
			gameObject.transform.localRotation = Quaternion.Euler (0, 0, 180);
			x = 0;
			y = -step;
		}
		if (Input.GetKey (KeyCode.A) && x != step) {
			gameObject.transform.localRotation = Quaternion.Euler (0, 0, 90);
			x = -step;
			y = 0;
		}
		if (Input.GetKey (KeyCode.D) && x != -step) {
			gameObject.transform.localRotation = Quaternion.Euler (0, 0, -90);
			x = step;
			y = 0;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			CancelInvoke ();
			InvokeRepeating ("move", 0, speed - 0.1f);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ();
			InvokeRepeating ("move", 0, speed);
		}
	}
		
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "food") {
			Destroy (collision.gameObject);
			MainUIContorller.Instance.UpdateUI ();
			FoodMaker.Instance.grawBody ();
			FoodMaker.Instance.initFood ();
		} else if (collision.tag == "body") {
			print ("self over");
		} else {
			print ("bound over");
			switch (collision.gameObject.name) {
			case "UpCollider":
				transform.localPosition = new Vector3 (transform.localPosition.x, -transform.localPosition.y+step, transform.localPosition.z);
				break;
			case "DownCollider":
				transform.localPosition = new Vector3 (transform.localPosition.x, -transform.localPosition.y-step, transform.localPosition.z);
				break;
			case "LeftCollider":
				transform.localPosition = new Vector3 (-transform.localPosition.x+3*step, transform.localPosition.y, transform.localPosition.z);
				break;
			case "RightCollider":
				transform.localPosition = new Vector3 (-transform.localPosition.x+6*step, transform.localPosition.y, transform.localPosition.z);
				break;
			}
		}
	}
		
}
