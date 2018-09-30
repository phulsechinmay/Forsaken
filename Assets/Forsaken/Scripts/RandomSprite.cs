using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour {

	public Sprite[] sprites;
	public int curSprite = -1;

	// Use this for initialization
	void Start () {

		if (curSprite == -1)
		{
			curSprite = Random.Range(0, sprites.Length);
		}
		else if(curSprite > sprites.Length){
			curSprite = sprites.Length - 1;
		}

		GetComponent<SpriteRenderer>().sprite = sprites[curSprite];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
