using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Choosing : MonoBehaviour
{
    public GameObject ChooseLine;

    //�I�����̏�ԁ@������0
    private int State = 0;

    //�I������SE
    [SerializeField] AudioSource ChooseAudio;
    //���莞��SE
    [SerializeField] AudioSource DecideAudio;
    //Ui�̃Z�b�e�B���O�܂ő����ҋ@������
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

            //��������b�N����
            ControlLock = true;
            //�V�[����ǂݍ��ރR���[�`��
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
