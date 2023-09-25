using System.IO;
using UnityEngine;

public class ScreenshotCapture : MonoBehaviour
{
    public string screenshotFolder = "Pictures";
    public KeyCode captureKey = KeyCode.S;

    private float captureDelay = 3f; // キャプチャの遅延時間（秒）
    private float captureTimer; // キャプチャのタイマー

    private void Update()
    {
        if (Input.GetKeyDown(captureKey))
        {
            StartCaptureTimer();
        }
        if (captureTimer > 0)
        {
            captureTimer -= Time.deltaTime;
            if (captureTimer <= 0)
            {
                CaptureScreenshot();
                captureTimer = 0;
            }
        }
    }
    private void StartCaptureTimer()
    {
        captureTimer = captureDelay;
    }

    private void CaptureScreenshot()
    {
        // ピクチャフォルダのパスを取得
        string pictureFolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures), screenshotFolder);

        // ピクチャフォルダが存在しなければ作成
        Directory.CreateDirectory(pictureFolderPath);

        // スクリーンショットのファイル名を作成
        string screenshotName = string.Format("Screenshot_{0:yyyy-MM-dd_HH-mm-ss}.png", System.DateTime.Now);

        // スクリーンショットを撮影し、ファイルに保存
        string screenshotFilePath = Path.Combine(pictureFolderPath, screenshotName);
        ScreenCapture.CaptureScreenshot(screenshotFilePath);

        // コンソールに撮影完了メッセージを表示
        Debug.Log("Screenshot captured: " + screenshotFilePath);
    }
}

