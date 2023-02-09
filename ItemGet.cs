using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemGet : MonoBehaviour
{

    public GameObject ItemUi;
    public GameObject GameSystem;
    public GameObject ItemInfoImage;
    public GameObject TutorialWhitePanel_S;
    public GameObject TutorialWhitePanel_L;
    public GameObject ExplanateZ;
    public GameObject PutAwayZ;
    public GameObject LastDecisionZ;

    public Image image;
    private Sprite ItemInfoSprite;
    [SerializeField] AudioSource ItemGetSound;
    [SerializeField] AudioSource ItemPutAudio;

    bool TouchItem = false;
    private GameObject ItemObject;
    string HaveItem;
    bool ItemUiFlag;


    const string ItemTag = "Item";
    const string ObjectTag = "Object";

    const string Bear = "Bear(Clone)";
    const string Knife = "Knife(Clone)";
    const string Flog = "Flog(Clone)";

    const string Table = "Table";
    const string Sofa = "Sofa";
    const string Plant = "Plant";

    const string Box = "box";


    // Start is called before the first frame update
    void Start()
    {
        ItemUiFlag = false;
        ItemInfoImage.SetActive(false);
        ExplanateZ.SetActive(false);
        PutAwayZ.SetActive(false);
        TutorialWhitePanel_S.SetActive(false);
        TutorialWhitePanel_L.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetItem();
        PutAwayItem();
        SetUi();
        IndicateZ();
        IndicateLastDecisionZ();
        LastScene();
        Debug.Log(ItemObject);
    }


    void GetItem() 
    {
        bool FireButton = Input.GetButtonDown("Fire1");
        if (TouchItem == true && FireButton == true && ItemObject.CompareTag(ItemTag))
        {
            
            Destroy(ItemObject);
            HaveItem = ItemObject.name;
            ItemUiFlag = true;

            ItemGetSound.Play();

            StartCoroutine("IndicatePutAwayZ");
            switch (HaveItem)
            {
                
                case Bear:
                    GameSystem.GetComponent<ItemUi>().ItemUiChange(HaveItem);

                    StartCoroutine("ItemInfo");
                    ItemInfoSprite = Resources.Load<Sprite>("ItemInfo_Bear");
                    image = ItemInfoImage.GetComponent<Image>();
                    image.sprite = ItemInfoSprite;
                    break;

                case Flog:
                    GameSystem.GetComponent<ItemUi>().ItemUiChange(HaveItem);

                    StartCoroutine("ItemInfo");
                    ItemInfoSprite = Resources.Load<Sprite>("ItemInfo_Flog");
                    image = ItemInfoImage.GetComponent<Image>();
                    image.sprite = ItemInfoSprite;
                    break;

                case Knife:
                    GameSystem.GetComponent<ItemUi>().ItemUiChange(HaveItem);

                    StartCoroutine("ItemInfo");
                    ItemInfoSprite = Resources.Load<Sprite>("ItemInfo_Knife");
                    image = ItemInfoImage.GetComponent<Image>();
                    image.sprite = ItemInfoSprite;
                    break;

                default:
                    break;
            
            
            
            }
        }



    }
    void IndicateZ()
    {
        if (TouchItem == true && ItemObject.CompareTag(ItemTag))
        {
            TutorialWhitePanel_S.SetActive(true);
            ExplanateZ.SetActive(true);



        }
        if (TouchItem == false || (TouchItem == true && !ItemObject.CompareTag(ItemTag))) {

            TutorialWhitePanel_S.SetActive(false);
            ExplanateZ.SetActive(false);

        }

    }


    IEnumerator IndicatePutAwayZ()
    {
        yield return new WaitForSeconds(2);
        TutorialWhitePanel_L.SetActive(true);
        PutAwayZ.SetActive(true);
        yield return new WaitForSeconds(5);
        PutAwayZ.SetActive(false);
        TutorialWhitePanel_L.SetActive(false);

    }

    void IndicateLastDecisionZ()
    {

        if (TouchItem == true && ItemObject.name == Box)
        {

            LastDecisionZ.SetActive(true);

        }

        else {


            LastDecisionZ.SetActive(false);

        }





    }

    void LastScene()
    {
        bool FireButton = Input.GetButtonDown("Fire1");
        if (TouchItem == true && ItemObject.name == Box && FireButton == true)
        {
            SceneManager.LoadScene("BadEnd");


        }


    }



    void PutAwayItem()
    {
        bool FireButton = Input.GetButtonDown("Fire1");
        switch (HaveItem)
        {
            case Bear:
                if(TouchItem==true && ItemObject.name==Sofa && FireButton==true)
                    {
                    Debug.Log("PutAway");
                    GameSystem.GetComponent<GameProgress>().DownRope();
                    GameSystem.GetComponent<ObjectManager>().ShowObject(HaveItem);
                    ItemPutAudio.Play();


                    HaveItem = null;
                    ItemUiFlag = false;
                }
                break;

            case Flog:
                if (TouchItem == true && ItemObject.name == Plant && FireButton == true)
                {
                    Debug.Log("PutAway");
                    GameSystem.GetComponent<GameProgress>().DownRope();
                    GameSystem.GetComponent<ObjectManager>().ShowObject(HaveItem);
                    ItemPutAudio.Play();

                    HaveItem = null;
                    ItemUiFlag = false;
                }
                break;


            case Knife:
                if (TouchItem == true && ItemObject.name == Table && FireButton == true)
                {
                    Debug.Log("PutAway");
                    GameSystem.GetComponent<GameProgress>().DownRope();
                    GameSystem.GetComponent<ObjectManager>().ShowObject(HaveItem);
                    ItemPutAudio.Play();

                    HaveItem = null;
                    ItemUiFlag = false;
                }
                break;

            default:
                break;
        
        
        }
    

    
    }


    void SetUi()
    {
        if (ItemUiFlag == true)
        {

            ItemUi.SetActive(true);

        }

        else
        {

            ItemUi.SetActive(false);
        
        }
    
    }


    void OnTriggerStay2D(Collider2D other)
    {
        TouchItem = true;
        ItemObject = other.gameObject;
    
    
    }


    void OnTriggerExit2D(Collider2D other)
    {

        TouchItem = false;


    }

    IEnumerator ItemInfo()
    {
        ItemInfoImage.SetActive(true);
        yield return new WaitForSeconds(2);
        ItemInfoImage.SetActive(false);

    }




}
