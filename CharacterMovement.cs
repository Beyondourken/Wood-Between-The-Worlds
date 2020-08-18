﻿using Assets.HeroEditor4D.Common.CharacterScripts;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


	public class CharacterMovement : MonoBehaviour
	{
		public CharacterAnimation CharacterAnimation;
		[SerializeField] private float speed;
		[SerializeField] protected Rigidbody2D myRigidbody;
		
		public void Start()
			{
				CharacterAnimation.SetState(CharacterState.Idle);
			}

	public void Update()
	{

		// Actions

		if (Input.GetKeyDown(KeyCode.A))
		{

			CharacterAnimation.Attack();
		}

		// Moves

		if (Input.GetKeyDown(KeyCode.I))
		{

			CharacterAnimation.SetState(CharacterState.Idle);
		}

		if (Input.GetKeyDown(KeyCode.E))
		{

			CharacterAnimation.SetState(CharacterState.Ready);
		}

		if (Input.GetKeyDown(KeyCode.W))
		{


			CharacterAnimation.SetState(CharacterState.Walk);
		}

		if (Input.GetKeyDown(KeyCode.R))
		{

			CharacterAnimation.SetState(CharacterState.Run);
		}

		if (Input.GetKeyDown(KeyCode.J))
		{

			CharacterAnimation.SetState(CharacterState.Jump);
		}

		if (Input.GetKeyDown(KeyCode.C))
		{

			CharacterAnimation.SetState(CharacterState.Climb);
		}

		if (Input.GetKeyDown(KeyCode.D))
		{

			CharacterAnimation.Die();
		}

		if (Input.GetKeyDown(KeyCode.H))
		{

			CharacterAnimation.Hit();
		}

		// Direction

		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{

			TurnLeft();
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			TurnRight();
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			TurnUp();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			TurnDown();
		}

	}

		public void TurnLeft()
		{
		

		
	
			
			GetComponent<Character4D>().SetDirection(Vector2.left);
		}

		public void TurnRight()
		{
		
			
	
			GetComponent<Character4D>().SetDirection(Vector2.right);
		}

		public void TurnUp()
		{
			
			
		
			GetComponent<Character4D>().SetDirection(Vector2.up);
		}

		public void TurnDown()
		{

		
		
		
			GetComponent<Character4D>().SetDirection(Vector2.down);
		}

        public void Show4Directions()
        {
            GetComponent<Character4D>().SetDirection(Vector2.zero);
		}
		public void Motion(Vector2 direction)
	{
			
			direction = direction.normalized;
			myRigidbody.velocity = direction * speed;
			

	}
	}

