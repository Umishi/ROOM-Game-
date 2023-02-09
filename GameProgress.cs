using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GameProgress : MonoBehaviour
{
    public float RopeDown1;
    public float RopeDown2;
    public float RopeDown3;

    private int DownProgress;
    [SerializeField] GameObject Rope;
    [SerializeField] GameObject Box;
    [SerializeField] GameObject GameSystem;
    // Start is called before the first frame update
    void Start()
    {
        Box.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DownRope()
    {
        switch (DownProgress)
        {
            case 0:
                Rope.transform.DOMove(new Vector2(0f, RopeDown1), 3f).SetEase(Ease.OutQuint);
                DownProgress = DownProgress + 1;
                GameSystem.GetComponent<Item_Pop>().Generate();
                break;


            case 1:
                Rope.transform.DOMove(new Vector2(0f, RopeDown2), 3f).SetEase(Ease.OutQuint);
                DownProgress = DownProgress + 1;
                GameSystem.GetComponent<Item_Pop>().Generate();
                break;

            case 2:
                Rope.transform.DOMove(new Vector2(0f, RopeDown3), 3f).SetEase(Ease.OutQuint);
                DownProgress = DownProgress + 1;
                Box.SetActive(true);
                break;

            case 3:
                break;

            default:
                break;


        }
        
    
    
    }


}
