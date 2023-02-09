using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] GameObject ObjectBear;
    [SerializeField] GameObject ObjectKnife;

    const string Bear = "Bear(Clone)";
    const string Knife = "Knife(Clone)";
    const string Flog = "Flog(Clone)";
    // Start is called before the first frame update
    void Start()
    {
        ObjectBear.SetActive(false);
        ObjectKnife.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowObject(string objects)
    {
        switch (objects)
        {
            case Bear:
                ObjectBear.SetActive(true);
                break;

            case Knife:
                ObjectKnife.SetActive(true);
                break;

            default:
                break;

        }
    
    
    
    }





}
