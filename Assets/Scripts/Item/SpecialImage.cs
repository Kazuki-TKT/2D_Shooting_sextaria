using UnityEngine;
using UnityEngine.UI;

public class SpecialImage : MonoBehaviour
{
    public int _spTypeInt;

    public Sprite _RtImage;

    [SerializeField]
    Image[] _spImage;

    [SerializeField]
    Sprite[] _spSprite;
    // Start is called before the first frame update
    void Start()
    {
        ChangeSpecialImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSpecialImage()
    {
        switch (_spTypeInt)
        {
            case 0:
                _RtImage = _spSprite[0];
                break;
            case 1:
                _RtImage = _spSprite[1];
                break;
            case 2:
                _RtImage = _spSprite[2];
                break;
        }
    
        for (int i = 0; i < _spImage.Length; i++)
        {
            switch (_spTypeInt)
            {
                case 0:
                    _spImage[i].sprite = _spSprite[0];
                    _RtImage = _spSprite[0];
                    break;
                case 1:
                    _spImage[i].sprite = _spSprite[1];
                    _RtImage = _spSprite[1];
                    break;
                case 2:
                    _spImage[i].sprite = _spSprite[2];
                    _RtImage = _spSprite[2];
                    break;
            }
        }
    }
}
