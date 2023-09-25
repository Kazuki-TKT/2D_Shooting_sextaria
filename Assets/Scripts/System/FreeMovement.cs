using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovement : MonoBehaviour
{
    GameStateManager gameState;
    public string EnemyName;
    GameObject bossObj;
    [SerializeField]
    UbhShotCtrl ubhShot;
    [SerializeField]
    private GameObject _explosionPrefab = null;
    [Space(20)]
    public float moveSpeed = 5f; // 移動速度
    [Space(20)]
    [Header("移動範囲")]
    public float minX = -4f; // X軸の最小値
    public float maxX = 4f; // X軸の最大値
    public float minY = -4f; // Y軸の最小値
    public float maxY = 4f; // Y軸の最大値
    [Space(20)]
    public float destroyDelay = 5f; // 破壊までの待機時間
    [Space(20)]
    public float minDelayTime = 2f; // 遅延処理までの最小待機時間
    public float maxDelayTime = 5f; // 遅延処理までの最大待機時間
    //----------------------
    private float delayTime; // 遅延処理までの待機時間
    private bool hasDelayedActionExecuted = false;

    private Vector3 movementDirection;

    bool flag = false;
    private void Awake()
    {
        bossObj = GameObject.Find(EnemyName);
        gameState = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }
    private void Start()
    {
        // 初期の移動方向をランダムに設定
        SetRandomMovementDirection();
        // ランダムな待機時間を設定
        delayTime = Random.Range(minDelayTime, maxDelayTime);
        Destroy(gameObject, destroyDelay);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ubhShot != null) Destroy(gameObject);
        }
    }
    private void Update()
    {
        // 移動方向に基づいて移動する
        transform.position += movementDirection * moveSpeed * Time.deltaTime;

        // 制限範囲内に制限する
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        // 制限範囲の端に到達した場合に移動方向を更新する
        if (transform.position.x <= minX || transform.position.x >= maxX ||
            transform.position.y <= minY || transform.position.y >= maxY)
        {
            SetRandomMovementDirection();
        }

        if (!hasDelayedActionExecuted && Time.time >= delayTime)
        {
            if (ubhShot != null) ExecuteDelayedAction();
            hasDelayedActionExecuted = true;
        }
        if (bossObj.activeSelf == false)
        {
            Destroy(this.gameObject);
            // 破壊されたときに行いたい処理をここに記述します
            //Debug.Log("対象のオブジェクトが破壊されました");
        }
        DeleteObj();
    }
    private void SetRandomMovementDirection()
    {
        // ランダムな移動方向を設定
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        movementDirection = new Vector3(randomX, randomY, 0f).normalized;
    }
    private void ExecuteDelayedAction()
    {
        ubhShot.StartShotRoutine();
        // 遅延処理をここに記述する
        //Debug.Log("Delayed action executed!");
    }

    public void Explosion()
    {
        if (_explosionPrefab != null)
        {
            Instantiate(_explosionPrefab, transform.position, transform.rotation);
        }
    }
    private void OnDestroy()
    {
        if (flag == false) Explosion();
    }

    public void DeleteObj()
    {
        if ( gameState._GameState.Value == GameState.GamePause)
        {
            return;
        }else if (gameState._GameState.Value == GameState.Gaming)
        {
            return;
        }
        else
        {
            flag = true;
            Destroy(gameObject);
        }
    }
}
