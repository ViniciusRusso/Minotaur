using UnityEngine;

public class SlotRenderer : MonoBehaviour
{
    public Slot Slot { get; set; }

    //The image for displaying the item icon.
    public UnityEngine.UI.Image iconImage;

    //The text for displaying the itemCount.
    public UnityEngine.UI.Text countText;

    private Sprite defaultSprite;

    private void Awake()
    {
        defaultSprite = iconImage.sprite;
        countText.text = string.Empty;
    }

    void Update()
    {

    }

    public void RenderSlot()
    {
        if (!(Slot?.Stack?.IsEmpty ?? true))
        {
            iconImage.sprite = Slot.Stack.Item.icon;
            countText.text = Slot.Stack.Count.ToString();
        }
        else
        {
            iconImage.sprite = defaultSprite;
            countText.text = string.Empty;
        }
    }

}