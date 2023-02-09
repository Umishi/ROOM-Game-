using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PoseUi : MonoBehaviour
{
    [SerializeField] GameObject Ui;
    [SerializeField] GameObject UiChoose_up;
    [SerializeField] GameObject UiChoose_down;
    [SerializeField] AudioSource ChooseAudio;


    //今ポーズ状態かどうか
    bool PoseFlag;

    //続けるとやめるの選択フラグ
    private int State=0;


    // Start is called before the first frame update
    void Start()
    {
        PoseFlag = false;
        Ui.SetActive(false);
        UiChoose_down.SetActive(false);
        UiChoose_up.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (PoseFlag == false)
        {
            ShowUp();

        }

        else if (PoseFlag == true)
        {

            UiChoosing();
            QuitUi();
            QuitGame();

        }
        
    }

    void UiChoosing()
    {
        
        bool StateChange = Input.GetButtonDown("Vertical");
        if (StateChange == true) {

            if (State == 0)
            {
                State=1;
                ChooseAudio.Play();
                UiChoose_up.SetActive(false);
                UiChoose_down.SetActive(true);
                
            }

            else if (State == 1) {

                State=0;
                ChooseAudio.Play();
                UiChoose_up.SetActive(true);
                UiChoose_down.SetActive(false);

            }
       
        }

    }


    void QuitUi()
    {
        bool Cancel = Input.GetButtonDown("Cancel");
        bool fire = Input.GetButtonDown("Fire1");
        if ((State == 0 && fire == true)|| Cancel == true) {
            State = 0;
            UiChoose_up.SetActive(true);
            UiChoose_down.SetActive(false);
            Ui.SetActive(false);
            PoseFlag = false;
        }
    
    
    
    }

    void QuitGame()
    {
        bool fire = Input.GetButtonDown("Fire1");
        if (State == 1 && fire == true)
        {
            SceneManager.LoadScene("Start");
        }
    }


    void ShowUp()
    {

        bool Cancel = Input.GetButtonDown("Cancel");
        if (Cancel == true)
        {

            Ui.SetActive(true);
            PoseFlag = true;

        }

    }


}
