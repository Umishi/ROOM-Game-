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
        //�X���C�h����_�\��
        RectTransform WidthSlideRect = WidthSlide.GetComponent<RectTransform>();
        RectTransform HeightSlideRect = HeightSlide.GetComponent<RectTransform>();
        //��
        WidthSlideRect.DOAnchorPos(new Vector2(0, -79), 0.8f)
        .SetEase(Ease.OutCubic);
        //�c
        HeightSlideRect.DOAnchorPos(new Vector2(0, 0), 0.8f)
        .SetEase(Ease.OutCubic);

        //�^�C�g���ƑI�����\��
        ROOM.SetActive(false);
        Menu.SetActive(false);
        StartCoroutine("Fade");

        //�I�Ԏ��ɕ\������_��\������֐�
        ChooseLineStart();
 
    }


    // Update is called once per frame
    void Update()
    {
      


    }

    //�^�C�g���ƃ��j���[�����ԍ��ŕ\��
    private IEnumerator Fade() {

        yield return new WaitForSeconds(1.0f);
        ROOM.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Menu.SetActive(true);
    
    
    }

    //�I�����̉��ɕ\������_�̕\��
    void ChooseLineStart() {

        RectTransform ChooseLineRect = ChooseLine.GetComponent<RectTransform>();

        ChooseLineRect.DOAnchorPos(new Vector2(25, -122), 1.5f)
        .SetEase(Ease.OutCubic);

        ChooseLineRect.DOScale(new Vector2(1f, 1), 1.8f)
        .SetEase(Ease.OutCubic);

    }



}
