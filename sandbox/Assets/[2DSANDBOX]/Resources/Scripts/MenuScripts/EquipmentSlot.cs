using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum SlotType
{
	Equipment
  , Tool

}

public class EquipmentSlot : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
	public Color colorNormal, colorHighlighted, colorSelected;
	public Image image;
	public Text counter;
	bool highlighted;
	bool selected;
	public bool canSelect = true;
  public SlotType Type;

	public int id;
	int count;
	bool isClicked = false;
	private float _timePresed = 0;

	

	

	private void Update()
	{
		if (SystemInfo.deviceType == DeviceType.Handheld)
		{
			if (isClicked)
			{
				_timePresed += Time.unscaledDeltaTime;
				if (_timePresed >= PauseScreen._instance._secondsForRightClick)
				{
					Select();
				}
			}
		}

}
	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("Click");
		if (SystemInfo.deviceType == DeviceType.Handheld)
		{
			if (eventData.button == PointerEventData.InputButton.Left) {
				isClicked = true;
			}
		}
		else
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			PauseScreen._instance.SlotClick(this);
		}
		else if (eventData.button == PointerEventData.InputButton.Right)
		{
			Select();
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{

		if (SystemInfo.deviceType == DeviceType.Handheld)
		{
			if (_timePresed < PauseScreen._instance._secondsForRightClick)
				PauseScreen._instance.SlotClick(this);
			_timePresed = 0;
			isClicked = false;
		}
	}
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			Select();
		}
	}

	public void Select()
	{
		if (!canSelect)
			return;

		if (count > 0)
		{
			//onSetActive.Invoke(this);
			PauseScreen._instance.SetActiveItem(this);
			GetComponent<Image>().color = colorSelected;
			selected = true;
		}
	}

	public void Deselect()
	{
		GetComponent<Image>().color = highlighted ? colorHighlighted : colorNormal;
		selected = false;
	}

	public void PointerEnter()
	{
		highlighted = true;
		GetComponent<Image>().color = selected ? colorSelected : colorHighlighted;
	}

	public void PointerExit()
	{
		highlighted = false;
		GetComponent<Image>().color = selected ? colorSelected : colorNormal;
	}

	private void OnDisable()
	{
		PointerExit();
	}

	public void SetId(int id)
	{
	  if (Type == SlotType.Tool) selected = false;
		this.id = id;
		Texture2D tex = ItemStore.getItem(id).texture;
		image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
	}

  public void ResetAll()
  {
	id = -1;
	image.sprite = null;
	SetCount(0);
	Deselect();
  }

	public void SetCount(int count)
	{
		this.count = count;
		image.enabled = count > 0;
		counter.text = count > 1 ? count.ToString() : "";
	}

	public int GetId()
	{
		return id;
	}

	public int GetCount()
	{
		return count;
	}

   
}