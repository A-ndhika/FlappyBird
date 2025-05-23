﻿using UnityEngine;

public class Player : MonoBehaviour {
	private Vector3 direction;
	private Vector3 position;
	private SpriteRenderer spriteRenderer;
	public Sprite[] sprites;
	private GameManager gameManager;
	private int spriteIndex;
	public float gravity = -9.8f;
	public float strength = 5f;

	private void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer>();
		gameManager = FindObjectOfType<GameManager>();
	}

	private void Start(){
		InvokeRepeating("AnimateSprite", 0.15f, 0.15f);
	}
	private void Update(){
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)){
			direction = Vector3.up * strength;
		}

		if (Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began){
				direction = Vector3.up * strength;
			}
		}

		direction.y = direction.y + gravity * Time.deltaTime;
		transform.position = transform.position + direction * Time.deltaTime;
	}
	
	private void AnimateSprite(){
		spriteIndex++;

		if (spriteIndex >= sprites.Length){
			spriteIndex = 0;
		}
		
		spriteRenderer.sprite = sprites[spriteIndex];
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Obstacle"){
			FindObjectOfType<GameManager>().GameOver();
		}
		else if (other.gameObject.tag == "Scoring"){
			FindObjectOfType<GameManager>().IncreaseScore();
		}
	}

	private void OnEnable(){
		if (!gameManager.IsGamePaused()){
			position = transform.position;
			position.y = 0f;
			transform.position = position;
			direction = Vector3.zero; 
		} 
	}

	public void ResetPlayerPosition(){
		transform.position = position; 
    	direction = Vector3.zero; 
	}
}