using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TilePlacer : Photon.PunBehaviour
{
	[SerializeField]
	private InventoryController _inventory;
	/// <summary>
	/// Whether or not the placer can edit the terrain
	/// </summary>
	[SerializeField]
	private bool _canEdit;

	/// <summary>
	/// Set the state of the placement
	/// </summary>
	/// <param name="state"></param>
	/// 
	private float _timePresed = 0;
	[SerializeField]
	private float _secondsForRightClick = 1;

	private bool _isClicked = false;
	public void toggleState(bool state)
	{
		_canEdit = state;
	}

	void Awake()
	{

	}
	
	void Start()
	{

	}

	void Update()
	{
		if (SystemInfo.deviceType == DeviceType.Handheld)
		{
			if (Input.GetMouseButton(0))
			{
				_timePresed += Time.unscaledDeltaTime;
				if (_timePresed >= _secondsForRightClick)
				{
					_isClicked = true;
					HandleInput(false);
				}
			}
			else if (Input.GetMouseButtonUp(0) && !_isClicked)
			{
				HandleInput(true);
			}
		}

		else if (SystemInfo.deviceType == DeviceType.Desktop)
		{
			if (DataManager.isMultiplayer)
			{
				Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

				if (_canEdit && Input.GetMouseButtonDown(0) && photonView.isMine) // left click, hit with item
				{
					World.instance.playerObj.GetComponent<Character>().StartToolAnimation();

					if (Input.GetKey(KeyCode.LeftShift))
					{
						World.instance.setBackground(new Tile(0, 0), pos);
					}
					else
					{
						World.instance.setBlock(new Tile(0, 0), pos);  //Removing Block step 1 ani
					}

					photonView.RPC("removeTile", PhotonTargets.OthersBuffered, pos);
				}
				else if (_canEdit && Input.GetMouseButtonDown(1) && photonView.isMine) // right click, use the item
				{
					photonView.RPC("placeTile", PhotonTargets.OthersBuffered, pos);
					// Send the right click 'event'
					World.instance.rightClick(pos);

					Stack stack = _inventory.getActiveItem();

					if (stack != null) // Is an item active?
					{
						// Check if the placement was successful, if not, refund the item back to the inventory
						if (stack.item.activateItem(pos))
						{
							_inventory.takeItem();
						}
					}
				}
			}
			else
			{
				Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

				if (_canEdit && Input.GetMouseButtonDown(0)) // left click, hit with item
				{
					if (EventSystem.current.IsPointerOverGameObject())
					{
						Debug.Log("Clicked on the UI");
					}
					else
					{
						World.instance.playerObj.GetComponent<Character>().StartToolAnimation();
						removeTile(pos);
					}

				}
				else if (_canEdit && Input.GetMouseButtonDown(1)) // right click, use the item
				{

					// Send the right click 'event'
					World.instance.rightClick(pos);

					Stack stack = _inventory.getActiveItem();

					if (stack != null) // Is an item active?
					{
						// Check if the placement was successful, if not, refund the item back to the inventory
						if (stack.item.activateItem(pos))
						{
							_inventory.takeItem();
						}
					}

				}

			}
		}
	}
			
	private void HandleInput(bool isLeft) {
		
		_timePresed = 0;
		_isClicked = false;
		if (DataManager.isMultiplayer)
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

			if (_canEdit && isLeft && photonView.isMine) // left click, hit with item
			{
				World.instance.playerObj.GetComponent<Character>().StartToolAnimation();

				if (Input.GetKey(KeyCode.LeftShift))
				{
					World.instance.setBackground(new Tile(0, 0), pos);
				}
				else
				{
					World.instance.setBlock(new Tile(0, 0), pos);  //Removing Block step 1 ani
				}

				photonView.RPC("removeTile", PhotonTargets.OthersBuffered, pos);
			}
			else if (_canEdit && !isLeft && photonView.isMine) // right click, use the item
			{
				photonView.RPC("placeTile", PhotonTargets.OthersBuffered, pos);
				// Send the right click 'event'
				World.instance.rightClick(pos);

				Stack stack = _inventory.getActiveItem();

				if (stack != null) // Is an item active?
				{
					// Check if the placement was successful, if not, refund the item back to the inventory
					if (stack.item.activateItem(pos))
					{
						_inventory.takeItem();
					}
				}
			}
		}
		else
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

			if (_canEdit && isLeft) // left click, hit with item
			{
				if (EventSystem.current.IsPointerOverGameObject())
				{
					Debug.Log("Clicked on the UI");
				}
				else
				{
					World.instance.playerObj.GetComponent<Character>().StartToolAnimation();
					removeTile(pos);
				}

			}
			else if (_canEdit && !isLeft) // right click, use the item
			{

				// Send the right click 'event'
				World.instance.rightClick(pos);

				Stack stack = _inventory.getActiveItem();

				if (stack != null) // Is an item active?
				{
					// Check if the placement was successful, if not, refund the item back to the inventory
					if (stack.item.activateItem(pos))
					{
						_inventory.takeItem();
					}
				}

			}

		}
	}

	[PunRPC]
	private void placeTile(Vector3 position)
	{
		if (!photonView.isMine)
		{
			////////World.instance.setBlock(new Tile(1, 0), position);

			World.instance.rightClick(position);

			Stack stack = _inventory.getActiveItem();

			if (stack != null) // Is an item active?
			{
				// Check if the placement was successful, if not, refund the item back to the inventory
				if (stack.item.activateItem(position))
				{
					_inventory.takeItem();
				}
			}

		}
	}

	[PunRPC]
	private void removeTile(Vector3 position)
	{
		if (!photonView.isMine)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				World.instance.setBackground(new Tile(0, 0), position);
			}
			else
			{
				World.instance.setBlock(new Tile(0, 0), position);  //Removing Block step 1 ani
			}
		}
	}

	public void SetActiveItemIndex(int id)
	{
		if (photonView.isMine)
		{
			photonView.RPC("setActiveItemIndex", PhotonTargets.OthersBuffered, id);
		}
	}

	public void SetItemEquipedState(int id , bool isEquiped)
	{
		if (photonView.isMine)
		{
			photonView.RPC("setItemEquipedState", PhotonTargets.OthersBuffered, new object[] { id, isEquiped });
		}
	}

	[PunRPC]
	private void setActiveItemIndex(int id)
	{
		if (!photonView.isMine)
		{
			_inventory.inventory.setActiveItem(id);
		}
	}

	[PunRPC]
	private void setItemEquipedState(int id, bool isEquiped)
	{
		if (!photonView.isMine)
		{
			if (id < _inventory.inventory.items.Count)
			{
				_inventory.inventory.items[id].item.IsEquiped = isEquiped;
			}
		}
	}

}