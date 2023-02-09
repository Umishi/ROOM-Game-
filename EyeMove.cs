using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMove : MonoBehaviour
{
    //ñ⁄ÇéÊÇ¡ÇƒÇ≠ÇÈ
    public GameObject Eye;

    //Uiè„ÇÃà íu
    RectTransform EyePosRect;

    //îÕàÕéwíË
    [System.Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;
    }

    [SerializeField] Bounds bounds;

    [SerializeField, Range(0f, 1f)] private float followStrength;


    // Start is called before the first frame update
    void Start()
    {
        EyePosRect = Eye.GetComponent<RectTransform>();
    }


    // Update is called once per frame
    void Update()
    {

        Eyemoving();

    }


    void Eyemoving()
    {
       
        var MousePos = Input.mousePosition;

        MousePos.x = Mathf.Clamp(MousePos.x, bounds.xMin, bounds.xMax);
        MousePos.y = Mathf.Clamp(MousePos.y, bounds.yMin, bounds.yMax);

        MousePos.z = 0f;

        EyePosRect.localPosition = Vector3.Lerp(EyePosRect.localPosition, MousePos, followStrength);

        Debug.Log(MousePos);


    }


}
