using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pop : MonoBehaviour
{
    [SerializeField]
    float RangeMin;

    [SerializeField]
    float RangeMax;

    List<int> ItemList= new List<int>() {1,2,3};

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int GenarateRand()
    {
        int rand = Random.Range(0,ItemList.Count-1);
        int ItemRand = ItemList[rand];
        return ItemRand;
    
    }

    void GenarateItem(int ItemRand)
    {
        //アイテムPOP範囲指定
        float Range = Random.Range(RangeMin, RangeMax);

        switch (ItemRand)
        {
            //ナイフをポップさせる
            case 1:
                GameObject Knife = (GameObject)Resources.Load("Knife");
                Instantiate(Knife, new Vector3(Range, 6.0f, 0.0f), Quaternion.identity);
                ItemList.Remove(1);
                break;

            //クマをポップさせる
            case 2:
                GameObject Bear = (GameObject)Resources.Load("Bear");
                Instantiate(Bear, new Vector3(Range, 6.0f, 0.0f), Quaternion.identity);
                ItemList.Remove(2);
                break;

            //カエルをポップさせる
            case 3:
                GameObject Flog = (GameObject)Resources.Load("Flog");
                Instantiate(Flog, new Vector3(Range, 6.0f, 0.0f), Quaternion.identity);
                ItemList.Remove(3);
                break;

        }


    }


    public void Generate()
    {


        GenarateItem(GenarateRand());


    }


}
