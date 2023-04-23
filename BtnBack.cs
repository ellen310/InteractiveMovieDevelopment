using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BtnBack : MonoBehaviour
{
    public bool isOnBtn;
    public Vector2 BtnOut, BtnIn;

    private void Start()
    {
        BtnOut = new Vector2(this.gameObject.transform.localPosition.x-60, this.gameObject.transform.localPosition.y);
        BtnIn = this.gameObject.transform.localPosition;
    }

    private void Update()
    {
        if (isOnBtn)
        {
            this.gameObject.transform.localPosition = Vector2.MoveTowards(this.gameObject.transform.localPosition, BtnOut, 1f);
        }
        else
        {
            this.gameObject.transform.localPosition = Vector2.MoveTowards(this.gameObject.transform.localPosition, BtnIn, 1f);
        }
    }


    public void OnClickBtnBack()
    {
        GameManager.I.continueScene = SceneManager.GetActiveScene().name;
        GameManager.I.JsonSave();
        SceneManager.LoadScene("Main");
    }

    public void PointEnter()
    {
        
        isOnBtn = true;
    }

    public void PointExit()
    {
        isOnBtn = false;
    }
}

