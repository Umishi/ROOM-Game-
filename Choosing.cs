using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Choosing : MonoBehaviour
{
    public GameObject ChooseLine;

    //選択肢の状態　初期は0
    private int State = 0;

    //選択時のSE
    [SerializeField] AudioSource ChooseAudio;
    //決定時のSE
    [SerializeField] AudioSource DecideAudio;
    //Uiのセッティングまで操作を待機させる
    bool ControlLock = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Lock");
    }

    // Update is called once per frame
    void Update()
    {
        if (ControlLock) 
        {
            return;
        }

        else
        {
            UiChoosing();
            Decide();

        }
    }

    void UiChoosing()
    {
        RectTransform ChooseLineRect = ChooseLine.GetComponent<RectTransform>();

        bool StateChange = Input.GetButtonDown("Vertical");

        if (StateChange == true)
        {

            if (State == 0)
            {
                State = 1;
                ChooseAudio.Play();
                ChooseLineRect.DOAnchorPos(new Vector2(25, -290), 0.3f)
                .SetEase(Ease.OutCubic);

            }

            else if (State == 1)
            {

                State = 0;
                ChooseAudio.Play();
                ChooseLineRect.DOAnchorPos(new Vector2(25, -122), 0.3f)
                .SetEase(Ease.OutCubic);

            }

        }

    }

    void Decide()
    {
        bool fire = Input.GetButtonDown("Fire1");
        if (State == 0 && fire == true)
        {
            DecideAudio.Play();
            Debug.Log("Start");

            //操作をロックする
            ControlLock = true;
            //シーンを読み込むコルーチン
            StartCoroutine("SceneChange");


        }
        else if (State == 1 && fire == true)
        {

            Debug.Log("Quit");
            Application.Quit();
        }


    }

    private IEnumerator Lock()
    {

        yield return new WaitForSeconds(1.5f);
        ControlLock = false;


    }

    private IEnumerator SceneChange()
    {

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Room");

    }


}
