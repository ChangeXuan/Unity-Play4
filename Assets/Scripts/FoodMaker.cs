using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMaker : MonoBehaviour {

	private static FoodMaker _instance;
	public static FoodMaker Instance {
		get {
			return _instance;
		}
	}

	private int yLimit = 5;
	private int xLimit = 10;
	private int offLeft = 1;
	private int offRight = 3;

	public int step;

	public GameObject foodPrefab;
	public Sprite[] foodSprites;

	public List<Transform> bodyList = new List<Transform> ();
	public GameObject bodyPrefab;
	public Sprite[] bodySprites = new Sprite[2];
	private Transform canvas;

	void Awake() {
		_instance = this;
		canvas = GameObject.Find ("Canvas").transform;
	}
		
	void Start () {
		initFood ();
		
	}

	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			initFood ();
		}
	}

	public void initFood() {
		GameObject food = GameObject.Instantiate (foodPrefab);
		food.transform.SetParent (transform,false);
		int index = Random.Range (0, foodSprites.Length);
		food.GetComponent<Image>().sprite = foodSprites [index];
		int x = Random.Range (-xLimit+offLeft, xLimit+offRight);
		int y = Random.Range (-yLimit, yLimit);
		food.transform.localPosition = new Vector3(x*step, y*step, gameObject.transform.position.z);
	}

	public void grawBody() {
		int index = (bodyList.Count%2==0)?0:1;
		GameObject body = Instantiate (bodyPrefab);
		body.transform.position = new Vector3 (2000, 2000, 0);
		body.GetComponent<Image> ().sprite = bodySprites [index];
		body.transform.SetParent (canvas, false);
		bodyList.Add (body.transform);
	}

	public void pushBody(Vector3 headPoint) {
		if (bodyList.Count > 0) {
//			bodyList[bodyList.Count-1].localPosition = headPoint;
//			bodyList.Insert (0, bodyList[bodyList.Count-1]);
//			bodyList.RemoveAt (bodyList.Count - 1);
			for (int i = bodyList.Count - 2; i >= 0; i--) {
				bodyList [i + 1].localPosition = bodyList [i].localPosition;
			}
			bodyList [0].localPosition = headPoint;
		}
	}
		
}
