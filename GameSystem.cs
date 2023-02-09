using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{

    [SerializeField] GameObject PoseUi;
    // Start is called before the first frame update
    void Start()
    {
        PoseUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ShowUi();
    }


    void ShowUi() 
    {
        bool Cancel = Input.GetButtonDown("Cancel");
        if (Cancel == true) {

            PoseUi.SetActive(true);
        
        }


    }


}
