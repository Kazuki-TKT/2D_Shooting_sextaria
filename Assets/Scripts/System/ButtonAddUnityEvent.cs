using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using KanKikuchi.AudioManager;
public class ButtonAddUnityEvent : MonoBehaviour, ISelectHandler
{
    public Image OtherSprite;

    public Image OrizinalSprite;
    public Sprite ChangeSprite;

    public UnityEvent myClickEvent;
    public UnityEvent mySelectEvent;

    public UnityEvent myFalseEvent;
    public Button button;

    [SerializeField]
    StoryScrollbar story;

    bool flag;
    public int EnemyNum;

    public Button TargetButton;

    public bool Oxia = false;
    Navigation nav;

    public bool OnEvent = false;
    private void OnEnable()
    {
        switch(EnemyNum)
        {
            case 0:
                OrizinalSprite.sprite = ChangeSprite;
                button.onClick.AddListener(InvokeEvent);
                break;
            case 1:
                if (ClearCheck_A() == true||OnEvent==true)
                {
                    OrizinalSprite.sprite = ChangeSprite;
                    button.onClick.AddListener(InvokeEvent);
                }
                else {
                    button.onClick.AddListener(InvokeFalseClickEvent);
                };
                break;
            case 2:
                if (ClearCheck_I() == true || OnEvent == true) {
                    OrizinalSprite.sprite = ChangeSprite;
                    button.onClick.AddListener(InvokeEvent);
                }
                else
                {
                    button.onClick.AddListener(InvokeFalseClickEvent);
                };
                break;
            case 3:
                if (ClearCheck_W() == true || OnEvent == true) {
                    OrizinalSprite.sprite = ChangeSprite;
                    button.onClick.AddListener(InvokeEvent);
                }
                else
                {
                    button.onClick.AddListener(InvokeFalseClickEvent);
                };
                break;
            case 4:
                if (ClearCheck_E() == true || OnEvent == true) {
                    OrizinalSprite.sprite = ChangeSprite;
                    button.onClick.AddListener(InvokeEvent);
                }
                else
                {
                    button.onClick.AddListener(InvokeFalseClickEvent);
                };
                break;
            case 5:
                if (ClearCheck_O() == true || OnEvent == true)
                {
                    OrizinalSprite.sprite = ChangeSprite;
                    button.onClick.AddListener(InvokeEvent);
                }
                else
                {
                    button.onClick.AddListener(InvokeFalseClickEvent);
                };
                break;
            default:
                button.onClick.AddListener(InvokeEvent);
                break;
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        switch (EnemyNum)
        {
            case 0:
                    InvokeSelectEvent();
                break;
            case 1:
                if (ClearCheck_A() == true || OnEvent == true)
                {
                    InvokeSelectEvent();
                }
                else { InvokeFalseEvent(); }
                    ;
                break;
            case 2:
                if (ClearCheck_I() == true || OnEvent == true)
                {
                    InvokeSelectEvent();
                }
                else { InvokeFalseEvent(); };
                break;
            case 3:
                if (ClearCheck_W() == true || OnEvent == true)
                {
                    InvokeSelectEvent();
                }
                else { InvokeFalseEvent(); };
                break;
            case 4:
                if (ClearCheck_E() == true || OnEvent == true)
                {
                    InvokeSelectEvent();
                }
                else { InvokeFalseEvent(); };
                break;
            case 5:
                if (ClearCheck_E() == true || OnEvent == true)
                {
                    InvokeSelectEvent();
                }
                else { InvokeFalseEvent(); };
                break;
            default:
                InvokeSelectEvent();
                break;
        }
        
    }

    public void InvokeEvent()
    {

        if (OtherSprite != null) ChangeSpriteNow();
        if (myClickEvent != null)
        {
            myClickEvent.Invoke();
            SEManager.Instance.Play(SEPath.MENU5_A);
        };
    }
    public void InvokeFalseClickEvent()
    {
        if (myClickEvent != null)
        {
            SEManager.Instance.Play(SEPath.MENU1_C);
        }
    }

    public void InvokeSelectEvent()
    {
        if(mySelectEvent!=null)
        mySelectEvent.Invoke();
    }
    public void InvokeFalseEvent()
    {
        if (myFalseEvent != null)
            myFalseEvent.Invoke();
    }
    public void MyFunction(UnityEvent someEvent)
    {
        // 引数のイベントを実行する処理を記述
        someEvent.Invoke();
    }

    public bool ClearCheck_A()
    {
        flag = story.StoryClearFlag(StoryState.StoryList.Story08);
        return flag;
    }
    public bool ClearCheck_I()
    {
        flag = story.StoryClearFlag(StoryState.StoryList.Story11);
        return flag;
    }
    public bool ClearCheck_W()
    {
        flag = story.StoryClearFlag(StoryState.StoryList.Story16);
        return flag;
    }
    public bool ClearCheck_E()
    {
        flag = story.StoryClearFlag(StoryState.StoryList.Story21);
        
        return flag;
    }
    public bool ClearCheck_O()
    {
        if (Oxia == false)
        {
            flag = story.StoryClearFlag(StoryState.StoryList.Story24);
        }
        else
        {
            flag = story.StoryClearFlag(StoryState.StoryList.Story25);
        }
        

        return flag;
    }
    public void ChangeSpriteNow()
    {
        OtherSprite.sprite = ChangeSprite;
    }

    public void ButtonSelect()
    {
        //現在セレクトしているボタンを取得し、
        //ホームボタンのセレクトアップに設定する
        GameObject selectedButton = EventSystem.current.currentSelectedGameObject;
        Button selectedButtonComponent = selectedButton.GetComponent<Button>();
        nav.selectOnUp = selectedButtonComponent;
        TargetButton.navigation = nav;
        //SEManager.Instance.Play(SEPath.SELECT_001_1);

    }
}
