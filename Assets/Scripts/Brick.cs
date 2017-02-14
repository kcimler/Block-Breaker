using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int brickCount = 0;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// keep track of breakable bricks
		if (isBreakable) {
			brickCount++;
		} 
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		AudioSource.PlayClipAtPoint (crack, transform.position, .8f);
		if (isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			brickCount--;
			Debug.Log (brickCount);
			levelManager.BrickDestroyed();
			puffSmoke();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void puffSmoke(){
		GameObject Puff = Instantiate (smoke,transform.position, Quaternion.identity) as GameObject;
		Puff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("MISSING SPRITE");
		}
	}
	
	// TODO Remove this method once we actually win!
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
