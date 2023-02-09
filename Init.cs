using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Init : MonoBehaviour
{
    public GameObject WidthSlide;
    public GameObject HeightSlide;
    public GameObject ROOM;
    public GameObject Menu;
    public GameObject ChooseLine;





    // Start is called before the first frame update
    void Start()
    {
        //スライドする棒表示
        RectTransform WidthSlideRect = WidthSlide.GetComponent<RectTransform>();
        RectTransform HeightSlideRect = HeightSlide.GetComponent<RectTransform>();
        //横
        WidthSlideRect.DOAnchorPos(new Vector2(0, -79), 0.8f)
        .SetEase(Ease.OutCubic);
        //縦
        HeightSlideRect.DOAnchorPos(new Vector2(0, 0), 0.8f)
        .SetEase(Ease.OutCubic);

        //タイトルと選択肢表示
        ROOM.SetActive(false);
        Menu.SetActive(false);
        StartCoroutine("Fade");

        //選ぶ時に表示する棒を表示する関数
        ChooseLineStart();
 
    }


    // Update is called once per frame
    void Update()
    {
      


    }

    //タイトルとメニューを時間差で表示
    private IEnumerator Fade() {

        yield return new WaitForSeconds(1.0f);
        ROOM.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Menu.SetActive(true);
    
    
    }

    //選択肢の下に表示する棒の表示
    void ChooseLineStart() {

        RectTransform ChooseLineRect = ChooseLine.GetComponent<RectTransform>();

        ChooseLineRect.DOAnchorPos(new Vector2(25, -122), 1.5f)
        .SetEase(Ease.OutCubic);

        ChooseLineRect.DOScale(new Vector2(1f, 1), 1.8f)
        .SetEase(Ease.OutCubic);

    }



}
