using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvasMy : MonoBehaviour
{
    public Fade fade;              //フェードキャンバス取得
    [SerializeField]
    private UISelectAction[] uiSelectAction;

    public GameObject[] _offObj;
    public GameObject[] _onObj;

    public bool last = false;
    //トランジションを掛けてシーン遷移する
    public void FadeAToB()
    {
        _offObj[0].SetActive(false);
        fade.FadeIn(0.4f, () =>
        {
            StartCoroutine(FadeCanvasAToB());
        });
    }

    public void FadeBToA()
    {
        _offObj[1].SetActive(false);
        if (last == false)
        {
            fade.FadeIn(0.4f, () =>
            {
                StartCoroutine(FadeCanvasBToA());
            });
        }
        else
        {
            fade.FadeIn(0.4f, () =>
            {
                StartCoroutine(FadeCanvasBToA_Story());
            });
            
        }
        
    }

    public void FadeA_IN()
    {
        _offObj[0].SetActive(false);
        fade.FadeIn(0.4f, () =>
        {
            StartCoroutine(FadeCanvasA_IN());
        });
    }
    public void FadeA_OUT()
    {
        
        StartCoroutine(FadeCanvasA_Out());
    }



    IEnumerator FadeCanvasAToB()
    {
        _onObj[0].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        yield return fade.FadeOut(0.8f);
        uiSelectAction[0].FirstSelect();
    }

    IEnumerator FadeCanvasBToA()
    {
        _onObj[1].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        yield return fade.FadeOut(0.81f);
        uiSelectAction[1].FirstSelect();
    }

    IEnumerator FadeCanvasBToA_Story()
    {
        _onObj[1].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        yield return fade.FadeOut(0.81f);
        if (uiSelectAction[1]._lastSelectButton != null)
        {
            uiSelectAction[1].LastSelect();
        }
        else
        {
            uiSelectAction[1].FirstSelect();
        }
        
    }
    IEnumerator FadeCanvasA_IN()
    {
        _onObj[0].SetActive(true);
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator FadeCanvasA_Out()
    {
        yield return fade.FadeOut(0.8f);
        uiSelectAction[0].FirstSelect();
    }
}
