using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUi : MonoBehaviour
{
    [SerializeField] GameObject ItemImage;
    public Image image;
    private Sprite ItemSprite;

    const string Bear = "Bear(Clone)";
    const string Knife = "Knife(Clone)";
    const string Flog = "Flog(Clone)";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemUiChange(string ItemName)
    {
        Debug.Log(ItemName);
        switch (ItemName)
        {
            
            case Bear:
                ItemSprite = Resources.Load<Sprite>("SpriteBear");
                image = ItemImage.GetComponent<Image>();
                image.sprite = ItemSprite;
                break;

            case Knife:
                ItemSprite = Resources.Load<Sprite>("SpriteKnife");
                image = ItemImage.GetComponent<Image>();
                image.sprite = ItemSprite;
                break;

            case Flog:
                ItemSprite = Resources.Load<Sprite>("SpriteFlog");
                image = ItemImage.GetComponent<Image>();
                image.sprite = ItemSprite;
                break;

            default:
                break;

        }


    }


}
