using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class QrCodeGenerate : MonoBehaviour
{
    //https://github.com/nenuadrian/qr-code-unity-3d-read-generate
    public SpriteRenderer QrSpriteRender;
    public Image QrImage;
    [SerializeField] string url;
    void Start()
    {
        QrImage.sprite = GenerateQR(url);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }

    public Texture2D generateQR(string text)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }

    public Sprite GenerateQR(string text) {
        Texture2D myQR=generateQR(text);
        Sprite sprite = Sprite.Create(myQR, new Rect(0, 0, myQR.width, myQR.height), Vector2.zero);
        return sprite;
    }
}
