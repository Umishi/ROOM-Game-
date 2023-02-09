using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnd : MonoBehaviour
{
    [SerializeField] AudioSource PutOn;
    [SerializeField] AudioSource HeartBeat;
    [SerializeField] AudioSource PutOut;
    [SerializeField] AudioSource EndBgm;

    [SerializeField] GameObject End1;
    [SerializeField] GameObject EndContents;
    [SerializeField] GameObject ZtoReturn;

    bool EndFlag=false;
    // Start is called before the first frame update
    void Start()
    {
        End1.SetActive(false);
        EndContents.SetActive(false);
        ZtoReturn.SetActive(false);
        StartCoroutine("End");
    }

    // Update is called once per frame
    void Update()
    {
        bool FireButton = Input.GetButtonDown("Fire1");
        if (FireButton == true && EndFlag) {

            SceneManager.LoadScene("Start");


        }
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(2);
        PutOn.Play();
        yield return new WaitForSeconds(3);
        HeartBeat.Play();
        yield return new WaitForSeconds(7);
        HeartBeat.Stop();
        PutOut.Play();
        yield return new WaitForSeconds(1);
        EndBgm.Play();
        yield return new WaitForSeconds(1);
        End1.SetActive(true);
        yield return new WaitForSeconds(2);
        EndContents.SetActive(true);
        yield return new WaitForSeconds(3);
        EndFlag = true;
        ZtoReturn.SetActive(true);

    }


}
