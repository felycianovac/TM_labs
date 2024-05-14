using System.Collections.Generic;
using Photon;
using UnityEngine.UI;
//for header
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : EntityPlayer {

	[Header("Player Movement")]
	public Heart heart; //Life Script
	public float speed = 8.0f; //Speed of walking
	public bool grounded = false; //Is player standing on ground checker
	public float jumpHeight = 3.0f; //How High can we jump

	[Header("MOBILE SYSTEM")]
	//MOBILE SYSTEM V4.0

	//Mobile Buttons to be displayed
	public GameObject mobileInventoryButton;
	public GameObject mobileWalkLeftButton;
	public GameObject mobileWalkRightButton;
	public GameObject mobileJumpButton;

	[Header("Player Components")]
	public AudioSource walk_audio; //Player Audio Source
	private Animator characterAnimator; //Player Animator
	private bool is_char_animate = false; //Should we animate player now checker
	private Vector3 face_left = new Vector3(-1, 1, 1); //what side should we face player (left,right)

	[Header("Player Walking Inputs")]
	private KeyCode left_keycode = KeyCode.A; //Walking left
	private KeyCode right_keycode = KeyCode.D; //Walking Right


	//Map Editor Size from 0,0 point                 x , y 10000 means 5000left and 5000right
	public static Vector2 worldSize = new Vector2(10000, 70);
	public Inventory inventory;




	

	//On game start
	public override void Awake()
	{
		//If it's multiplayer - we load and make margins of world size smaller (so players are together)
		if(DataManager.isMultiplayer)
		{
			worldSize = new Vector2(70, 70); //Size of world is 70,70 to be possible to render straight away
		}
		else //If it's singleplayer - size is huge.
		{
			worldSize = new Vector2(10000, 70); //size of world singleplayer is 10000 wide and 70 up/down 
		}
		base.Awake();
		characterAnimator = (Animator)GetComponent<Animator>();


	}

	public override void Start()
	{
		//Sending Photon information
		base.Start();
		if (DataManager.isMultiplayer)
		{
			PhotonNetwork.sendRate = 20; 
			PhotonNetwork.sendRateOnSerialize = 20;
			if (!photonView.isMine)
			{
				World.characters.Add(this.transform);
				GetComponent<Rigidbody2D>().gravityScale = 0;
			}
		}



		//IF WE RUN THE GAME ON MOBILE - DISPLAY INVENTORY BUTTON AND MOVEMENT BUTTONS
		if(SystemInfo.deviceType == DeviceType.Handheld)
		{
			mobileJumpButton.SetActive(true);
			mobileWalkLeftButton.SetActive(true);
			mobileWalkRightButton.SetActive(true);
			mobileInventoryButton.SetActive(true);
		}
		else //If we run the game on pc or anywhere
		{
			mobileJumpButton.SetActive(false);
			mobileWalkLeftButton.SetActive(false);
			mobileWalkRightButton.SetActive(false);
			mobileInventoryButton.SetActive(false);
		}
	}

	//On Collision with ground - we mark grounded as true
	void OnCollisionStay2D(Collision2D col)
	{
		grounded = true;
	}

	//If we have no collision with ground (we jump) let's mark grounded as false
	void OnCollisionExit2D(Collision2D coll)
	{
		grounded = false;
	}

	//If we touch enemy - we lose HP
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "enemy")
		{
			heart.Hit(); //Take 1 hit from our Heart Script
			Debug.Log("Tool ID: " + toolID);
		}
	}

	//PHOTON Multiplayer Walking, Jumping - overall movement + MOBILE MOVEMENT
	public override void Update()
	{
		bool isWalking = Input.GetKey(left_keycode) || Input.GetKey(right_keycode) || PointerDownLeft == true || PointerDownRight == true;
    	bool speedBoost = Input.GetKey(KeyCode.S) && (Input.GetKey(left_keycode) || Input.GetKey(right_keycode));
		float currentSpeed = speed;

		if (speedBoost)
		{
			currentSpeed = 9.0f;
		}
		if (DataManager.isMultiplayer)
		{
			if (photonView.isMine)
			{
				base.Update();

				Vector3 pos = transform.position;
				if (Input.GetKey(left_keycode) || PointerDownLeft == true)
				{
					if (!is_char_animate)
					{
						is_char_animate = true;
						characterAnimator.SetBool("walking", true);
						walk_audio.Play();
					}

					// walk_audio.PlayOneShot(walk_audio.clip, 1);

					pos.x -= speed * Time.deltaTime;

					if (pos.x < -70)
						pos.x = -70;

					float tempX = pos.x;
					foreach (Transform t in World.characters)
					{
						if (t.position.x > tempX)
						{
							tempX = t.position.x;
						}
					}
					if (tempX > pos.x + 8)
					{
						pos.x = tempX - 8;
					}
					transform.position = pos;
					transform.localScale = face_left; 
				}
				else if (Input.GetKey(right_keycode) || PointerDownRight == true)
				{
					if (!is_char_animate)
					{
						is_char_animate = true;
						characterAnimator.SetBool("walking", true);
						walk_audio.Play();
					}
					// walk_audio.PlayOneShot(walk_audio.clip, 1);

					pos.x += speed * Time.deltaTime;

					if (pos.x > 140)
						pos.x = 140;

					float tempX = pos.x;
					foreach (Transform t in World.characters)
					{
						if (t.position.x < tempX)
						{
							tempX = t.position.x;
						}
					}
					if (tempX < pos.x - 8)
					{
						pos.x = tempX + 8;
					}

					transform.position = pos;
					transform.localScale = Vector3.one;
				}
				else if (is_char_animate)
				{
					is_char_animate = false;
					characterAnimator.SetBool("walking", false);
					walk_audio.Stop();
				}
				if (Input.GetKeyUp(KeyCode.Space) || PointerClickJumping == true)
				{
					if (grounded)
					{
						photonView.RPC("JumpRemotely", PhotonTargets.Others);
						GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
						grounded = false;
						PointerClickJumping = false;
					}
				}

				if (transform.position.y > worldSize.y)
				{
					Vector3 p = transform.position;
					p.y = worldSize.y;
					transform.position = p;
				}

				if (transform.position.y < -worldSize.y)
				{
					Vector3 p = transform.position;
					p.y = -worldSize.y;
					transform.position = p;
				}
			}
		}
		else
		{
			//SINGLEPLAYER WALKING
			base.Update();

			Debug.Log("Tool ID: " + inventory.activeIndex);

			Vector3 pos = transform.position;
			if (Input.GetKey(left_keycode) || PointerDownLeft == true)
			{
				if (!is_char_animate)
				{
					is_char_animate = true;
					characterAnimator.SetBool("walking", true);
					walk_audio.Play();
				}

				// walk_audio.PlayOneShot(walk_audio.clip, 1);

				pos.x -= currentSpeed * Time.deltaTime;

				if (pos.x < -worldSize.x)
					pos.x = -worldSize.x;

				transform.position = pos;
				transform.localScale = face_left;

			}
			else if (Input.GetKey(right_keycode) || PointerDownRight == true)
			{
				if (!is_char_animate)
				{
					is_char_animate = true;
					characterAnimator.SetBool("walking", true);
					walk_audio.Play();
				}
				// walk_audio.PlayOneShot(walk_audio.clip, 1);

				pos.x += currentSpeed * Time.deltaTime;

				if (pos.x > worldSize.x)
					pos.x = worldSize.x;

				transform.position = pos;
				transform.localScale = Vector3.one;
			}
			else if (is_char_animate)
			{
				is_char_animate = false;
				characterAnimator.SetBool("walking", false);

				walk_audio.Stop();
			}
			if (Input.GetKeyDown(KeyCode.Space) || PointerClickJumping == true)
			{
				if (grounded)
				{
					GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
					grounded = false;
					PointerClickJumping = false;
				}

			}

			if (transform.position.y > worldSize.y)
			{
				Vector3 p = transform.position;
				p.y = worldSize.y;
				transform.position = p;
			}

			if (transform.position.y < -worldSize.y)
			{
				Vector3 p = transform.position;
				p.y = -worldSize.y;
				transform.position = p;
			}
		}
	}

	//Jumping in Multiplayer (synchronizing it)
	[PunRPC]
	void JumpRemotely()
	{
		//GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
		grounded = false;
	}

	void SpeedUp()
	{
		speed = 16.0f;
	}

	//Taking Tool in photon multiplayer
	public override void StartToolAnimation()
	{
		if (DataManager.isMultiplayer)
		{
			if (photonView.isMine)
			{
				photonView.RPC("ToolAnimateRemotely", PhotonTargets.Others);
				base.StartToolAnimation();
				characterAnimator.SetTrigger("tool");
			}
		}
		else //Taking Tool in singleplayer
		{
			base.StartToolAnimation();
			characterAnimator.SetTrigger("tool");
		}
	}

	//Animate tools in multiplayer 
	[PunRPC]
	void ToolAnimateRemotely()
	{
		base.StartToolAnimation();
		characterAnimator.SetTrigger("tool");
	}

	Vector3 toBePos = new Vector3();
	private void FixedUpdate()
	{
		if (DataManager.isMultiplayer)
		{
			if (!photonView.isMine)
			{
				toBePos = this.gameObject.transform.position;
				toBePos.x = receivedPositionX;
				toBePos.y = receivedPositionY;
				this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, toBePos, Time.fixedDeltaTime * 8);
				//this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, receivedPosition, 0.5f);
			}
		}
	}

	//Out tools
	public int toolCount = 0;
	public int toolID = 0;
	public bool isHoldTool = false;
	float receivedPositionX = 0.0f;
	float receivedPositionY = 0.0f;
	bool isFirstData = true;
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(this.gameObject.transform.position.x);
			stream.SendNext(this.gameObject.transform.position.y);
			stream.SendNext(toolCount);
			stream.SendNext(toolID);
			//Debug.Log("Sending");
		}
		else
		{
			float x = (float)stream.ReceiveNext();
			float y = (float)stream.ReceiveNext();
			toolCount = (int)stream.ReceiveNext();
			toolID = (int)stream.ReceiveNext();
			if (receivedPositionX > x)
			{
				if(!is_char_animate)
				{
					is_char_animate = true;
					characterAnimator.SetBool("walking", true);
				}
				this.gameObject.transform.localScale = face_left;
			}
			else if(receivedPositionX < x)
			{
				if (!is_char_animate)
				{
					is_char_animate = true;
					characterAnimator.SetBool("walking", true);
				}
				this.gameObject.transform.localScale = Vector3.one;
			}
			else
			{
				is_char_animate = false;
				characterAnimator.SetBool("walking", false);
			}
			receivedPositionX = x;
			receivedPositionY = y;
			//Debug.Log("Receiving");
			if (isFirstData)
			{
				Vector3 pos = this.transform.position;
				pos.x = receivedPositionX;
				pos.y = receivedPositionY;
				isFirstData = false;
				this.gameObject.transform.position = pos;
			}

			//It puts tool to 73rd slot in inventory (our eq)
			EquipmentSlot toolSlot = PauseScreen._instance.equipmentSlots[73];
			//TODO it set sprite every update. need to fix

			//We have 3 different tools, and once they are wear - update image sprite
			if (toolCount > 0 && (toolID == 30 || toolID == 31 || toolID == 32)){
				UpdateTool(toolSlot.image.sprite);
				if(toolID == 30){
					isHoldTool = true;
				}
			}

			else
				UpdateTool(null);

		}
		
	}



	//MOBILE SYSTEM V4.0
	//This mobile system is very easy and needs some improvement. But it will get you to your goal.

	//First I need to separate walking for mobile left and right and then put it to buttons
	//Then I need to add UI Equipement for mobile to be displayed on toggle

	//MOBILE INVENTORY SCRIPT FUNCTIONALITY IS WRITTEN IN PauseScreen.cs script (Found In Canvas on your world map)

	//Walking Mobile Left
	public bool PointerDownLeft
	{
		get;
		private set;
	}

	//Walking Mobile Right
	public bool PointerDownRight
	{
		get;
		private set;
	}

	//Jumping Mobile 
	public bool PointerClickJumping
	{
		get;
		private set;
	}

	//Opening Inventory
	public bool OnPointerClickInventoryOpen
	{
		get;
		set;
	}
	//Closing Inventory
	public bool OnPointerDownInventoryClose
	{
		get;
		set;
	}

	//Setting walking true on left button
	public void OnPointerDownLeft()
	{
		PointerDownLeft = true;
	}

	//Setting walking false on left button
	public void OnPointerUpLeft()
	{
		PointerDownLeft = false;
	}

	//Setting walking true on right button
	public void OnPointerDownRight()
	{
		PointerDownRight = true;
	}

	//Setting walking false on right button
	public void OnPointerUpRight()
	{
		PointerDownRight = false;
	}

	//Jumping Mobile True
	public void OnPointerClickJump()
	{
		PointerClickJumping = true;
	}

	//Setting Opening Inventory on Button Click
	public void OnPointerDownInventory()
	{
		OnPointerClickInventoryOpen = true;
	}
	//Then we have a trick that it won't open inventory infinitely so we set it to false on button UP
	public void OnPointerUpInventory()
	{
		OnPointerClickInventoryOpen = false;
	}

	//Setting Closing Inventory on Button Click
	public void OnPointerDownCloseInventory()
	{
		OnPointerDownInventoryClose = true;
	}
	//Then we have a trick that it won't close inventory infinitely so we set it to false on button UP
	public void OnPointerUpCloseInventory()
	{
		OnPointerDownInventoryClose = false;
	}


}