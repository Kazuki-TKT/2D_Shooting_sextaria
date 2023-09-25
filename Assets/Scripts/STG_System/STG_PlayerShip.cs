using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using UniRx;
using InputAsRx;
using MoreMountains.Feedbacks;
using KanKikuchi.AudioManager;
public class STG_PlayerShip : MonoBehaviour
{
    [SerializeField] SEAssistant sEAssistant;
    [SerializeField] private ParticleSystem particleHit;
    [SerializeField] private ParticleSystem breakHeart;
    [SerializeField]
    GameStateManager _gameState;
    [SerializeField]
    MMFeedbacks _mmFeedback;
    [SerializeField]
    MMFeedbacks _shakeFeedback;
    [SerializeField]
    MMFeedbacks _lifeFeedback;
    //　ゲームのスコア
    [FormerlySerializedAs("SCORE")]
    [SerializeField]
    STG_Score _score;

    [FormerlySerializedAs("_Speed")]
    public float m_speed;

    public float defaultSpeed;
    public float changeSpeed;

    [SerializeField, FormerlySerializedAs("_ExplosionPrefab")]
    private GameObject m_explosionPrefab = null;

    private Animator m_animator;

    //　HP関係
    [SerializeField]
    public Slider _hpSlider;
    [SerializeField]
    public Text _hpText;

    const int HP_MIN = 0;     // 最小値
    const int HP_MAX = 100;   // 最大値
    public int hp_MAX => HP_MAX;

    //ライフ
    [SerializeField]
    public GameObject[] _lifeObj;
    public int _lifePoint = 3;

    //PowerUp
    [SerializeField]
    public STG_PowerUp _PowerUp;

    //スペシャル
    [SerializeField]
    public GameObject[] _specialObj;
    public int _specialPoint = 0;
    //PlayeのHP
    public ReactiveProperty<int> pHP = new ReactiveProperty<int>();

    //無敵時間のbool
    ReactiveProperty<bool> _noDamage = new ReactiveProperty<bool>(false);
    [SerializeField]
    int _noDamageTime = 2;

    //攻撃のキー
    public
    KeyCode Special = KeyCode.X;

    public GameObject[] itemPrefab;

    private void Awake()
    {
        pHP.Value = HP_MAX;
        _lifePoint = 3;
    }
    private void Start()
    {
        m_animator = GetComponent<Animator>();
        pHP
            .Where(x => x <= 0 && _gameState._GameState.Value == GameState.Gaming) // x <= 0 で HP が 0 以下になったら
            .TakeWhile(_ => _lifePoint > 0) // _lifePoint が 0 より大きい間
            .Subscribe(_ =>
            {
                Dead();
                Debug.Log($"<color=#4169e1><b>残機:{_lifePoint}</b></color>");
                if (_lifePoint <= 0)
               {
                   GameOver(); // _lifePoint が 0 以下になったら手動で OnComplete() を呼び出す
               }
            })
            .AddTo(this);

        _noDamage
            .Where(x => x == true && _gameState._GameState.Value == GameState.Gaming)
            .TakeWhile(x => _lifePoint != 0)
            .Subscribe(_ => StartCoroutine(NoDamageTime()))
            .AddTo(this);

        //スペシャル
        InputAsObservable.GetKeyDown(Special)
       .Where(_ => _specialPoint != 0 && _gameState._GameState.Value == GameState.Gaming)
       .Subscribe(_ => SpecialAt())
       .AddTo(this);
    }

    private void OnDisable()
    {
        //pHP.Value = HP_MAX;
        //_hpSlider.value = pHP.Value;
        //_hpText.text = pHP.Value.ToString();
        if (_noDamage.Value == true) _noDamage.Value = false;
        Debug.Log(_noDamage.Value);
        _lifePoint = 3;
        for (int i = 0; i < _lifeObj.Length; i++)
        {
            if (_lifeObj[i].activeSelf == false) _lifeObj[i].SetActive(true);
        }
    }

    private void OnEnable()
    {
        _specialPoint = 0;
        SpecialAt();
        pHP.Value = HP_MAX;
        _hpSlider.value = pHP.Value;
        _hpText.text = pHP.Value.ToString();
    }

    public void Explosion()
    {
        if (m_explosionPrefab != null)
        {
            Instantiate(m_explosionPrefab, transform.position, transform.rotation);
        }
    }

    public Animator GetAnimator()
    {
        return m_animator;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string cName = collision.gameObject.tag;
        switch (cName)
        {
            case "DropItem":
                collision.GetComponent<GetItemIo>().GetUseAbility();
                //ドロップアイテムのGetUseAbility()を実行                                           
                //if (pHP.Value > HP_MAX) pHP.Value = HP_MAX;//体力がHP_MAXより上がらないように                                                
                // pHP.Value = System.Math.Min(pHP.Value, HP_MAX);

                break;
            case "EBullet":
                if (_gameState._GameState.Value != GameState.Gaming) return;

                _lifeFeedback.PlayFeedbacks();
                _shakeFeedback.PlayFeedbacks();
                sEAssistant.Play();
                particleHit.Play();
                if (_noDamage.Value == false)
                {
                    int attackP = collision.GetComponentInParent<IBullet>().BulletAtk;
                    pHP.Value -= attackP;//敵弾に当たったので体力減少
                    pHP.Value = System.Math.Max(pHP.Value, HP_MIN);
                    _hpSlider.value = pHP.Value;
                    _hpText.text = pHP.Value.ToString();
                    //_score.AddPoint(-attackP); //敵弾に当たったのでスコア減点                    
                }
                UbhBullet bullet = collision.GetComponentInParent<UbhBullet>();// 弾を戻す
                if (bullet != null && bullet.isActive)
                {
                    UbhObjectPool.instance.ReleaseBullet(bullet);
                }
                break;
            case "Enemy":
                if (_gameState._GameState.Value != GameState.Gaming) return;
                _lifeFeedback.PlayFeedbacks();
                _shakeFeedback.PlayFeedbacks();
                particleHit.Play();
                pHP.Value -= 100;
                pHP.Value = System.Math.Max(pHP.Value, HP_MIN);
                _hpSlider.value = pHP.Value;
                _hpText.text = pHP.Value.ToString();
                _score.AddPoint(-1000);
                if (_lifePoint == 1) pHP.Value -= 10;//最後の時、UniRXを発火させるため
                break;
        }
    }

    private void Dead()
    {
        breakHeart.Play();
        _noDamage.Value = true;
        Explosion();
        _lifePoint -= 1;
        if (100 <= _PowerUp.m_power && _PowerUp.m_power < 200 && _lifePoint > 0)
        {
            Vector3 pos = transform.position;
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(pos.x + 1.4f, pos.x - 1.4f);
            Instantiate(itemPrefab[0], new Vector3(x, pos.y + 2f, pos.z), Quaternion.identity);
        }
        else if (200 == _PowerUp.m_power && _lifePoint > 0)
        {
            Vector3 pos = transform.position;
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(pos.x + 1.4f, pos.x - 1.4f);
            Instantiate(itemPrefab[1], new Vector3(x, pos.y + 2f, pos.z), Quaternion.identity);
        }
        _PowerUp.DeadPower();
        _lifeObj[_lifePoint].SetActive(false);
        Debug.Log("プレイヤーの残機 :" + _lifePoint);
        
    }

    private IEnumerator NoDamageTime()
    {
        // _noDamageTime間待つ
        pHP.Value = HP_MAX;
        m_animator.SetTrigger("Fukki");
        yield return new WaitForSeconds(_noDamageTime);
        _noDamage.Value = false;
    }

    private void GameOver()
    {
        _specialPoint = 0;
        SpecialAt();
        _gameState._GameState.Value = GameState.GameOver;
        gameObject.SetActive(false);
        StopCoroutine(NoDamageTime());
        _mmFeedback.PlayFeedbacks();
        if(_noDamage.Value == true)_noDamage.Value = false;
        Debug.Log("GameOver");
    }

    public void SpecialAt()
    {
        GameObject special;
        switch (_specialPoint)
        {
            case 0:
                _specialObj[0].SetActive(false);
                _specialObj[1].SetActive(false);
                _specialObj[2].SetActive(false);
                break;
            case 1://〇
                special = _PowerUp.Special();
                special.GetComponent<STG_SpecialIO>().SpecialAttack();
                _specialPoint -= 1;
                _specialObj[0].SetActive(false);
                _score.AddPoint(500);
                break;
            case 2://〇〇
                special = _PowerUp.Special();
                special.GetComponent<STG_SpecialIO>().SpecialAttack();
                _specialPoint -= 1;
                _specialObj[1].SetActive(false);
                _score.AddPoint(1050);
                break;
            case 3://〇〇〇
                special = _PowerUp.Special();
                special.GetComponent<STG_SpecialIO>().SpecialAttack();
                _specialPoint -= 1;
                _specialObj[2].SetActive(false);
                _score.AddPoint(1500);
                break;
        }

    }
    
    public void ScoreAdds(int x)
    {
        _score.AddPoint(x);
    }
    public void PowerMax()
    {
        _PowerUp.m_power = 200;
    }
}
