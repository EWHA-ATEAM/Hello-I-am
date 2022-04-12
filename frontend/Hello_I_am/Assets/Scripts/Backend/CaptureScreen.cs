using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CaptureScreen : MonoBehaviour
{
    [SerializeField]
    private Camera unityCamera;
    [SerializeField]
    private GameObject checkScreenShot;
    [SerializeField]
    private GameObject captureFlash;

    private int width;
    private int height;
    private int depth = 10; // 어느정도까지 잘 보이게 할 건지..?

    private GameObject ARObject;

    public bool nowCapturing { get; private set; }  // 외부에서 참조만 가능

    private void Start()
    {
        width = Screen.width;
        height = Screen.height;
        ARObject = GameObject.Find("AR Session Origin").GetComponent<ARTapToPlaceAnimal>().AnimalAR;
    }

    public void onClickScreenShot()
    {
        nowCapturing = true;
        StartCoroutine(captureScreenShot());
    }

    // 한 프레임이 끝난 뒤 촬영하기 위해서 -> 다 출력되지 않은 상태로 촬영이 될까봐
    private IEnumerator captureScreenShot()
    {
        // 동물 AR 캡처 안 되도록 -> 서버 전송용
        ARObject.SetActive(false);
        yield return new WaitForEndOfFrame();
        byte[] img = capture();
        ARObject.SetActive(true);


        // 동물 AR 포함하여 캡쳐 -> 사용자 화면에 보여줄 것
        yield return new WaitForEndOfFrame();
        byte[] imgWithAnimal = capture();

        Texture2D tex = new Texture2D(1, 1, TextureFormat.RGB24, false);
        tex.LoadImage(imgWithAnimal);
        Sprite custom_sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one * 0.5f);
        checkScreenShot.SetActive(true);
        checkScreenShot.GetComponent<Image>().sprite = custom_sprite;
        captureFlash.SetActive(true);

        // 파일 저장 코드
        // File.WriteAllBytes("C:/Users/zmin9/Desktop/test.jpg", img);

        // 만약 http 통신으로 보낼경우
        GameObject.Find("Canvas").GetComponent<ServerCommunicate>().sendToServer(img);


        //아래 코드를 활성화 시키면 이상한 sprite가 뜸
        //Destroy(tex);

        nowCapturing = false;
        gameObject.SetActive(false);
    }

    private byte[] capture()
    {
        // render texture
        RenderTexture rt = new RenderTexture(width, height, depth);
        // render texture를 저장할 Texture2D
        Texture2D screenShot = new Texture2D(width, height, TextureFormat.RGB24, false); // 일단 컬러로 해뒀는데 흑백이어도 상관 없다면 흑백으로 변경

        // 캡쳐후 기존 카메라 렌더 텍스쳐를 돌려받기 위해 임시로 저장
        RenderTexture temp = unityCamera.targetTexture;
        unityCamera.targetTexture = rt;

        // 화면 렌더링
        unityCamera.Render();

        RenderTexture.active = rt;

        screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        screenShot.Apply();

        byte[] imgBytes = screenShot.EncodeToJPG();

        unityCamera.targetTexture = temp;
        Destroy(screenShot);

        return imgBytes;
    }
}