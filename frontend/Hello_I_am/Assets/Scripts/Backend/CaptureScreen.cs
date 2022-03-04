using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureScreen : MonoBehaviour
{
    [SerializeField]
    private Camera unityCamera;

    private int width;
    private int height;
    private int depth = 10; // 어느정도까지 잘 보이게 할 건지..?

    public bool nowCapturing { get; private set; }  // 외부에서 참조만 가능

    private void Start()
    {
        width = Screen.width;
        height = Screen.height;
    }

    public void onClickScreenShot()
    {
        nowCapturing = true;
        StartCoroutine(captureScreenShot());
    }

    // 한 프레임이 끝난 뒤 촬영하기 위해서 -> 다 출력되지 않은 상태로 촬영이 될까봐
    private IEnumerator captureScreenShot()
    {
        yield return new WaitForEndOfFrame();

        // render texture
        RenderTexture rt = new RenderTexture(width, height, depth);
        // render texture를 저장할 Texture2D
        Texture2D screenShot = new Texture2D(width, height, TextureFormat.RGB24, false); // 일단 컬러로 해뒀는데 흑백이어도 상관 없다면 흑백으로 변경 필요
        unityCamera.targetTexture = rt;

        // 화면 렌더링
        unityCamera.Render();

        RenderTexture.active = rt;

        screenShot.ReadPixels(new Rect(0, 0, width, height),0,0);
        screenShot.Apply();

        // 만약 http 통신으로 보낼경우
        byte[] imgBytes = screenShot.EncodeToJPG();

        /*
        
        ServerCommunicate.cs 좀 수정하고 함수 호출해서 보내면 될 듯 합니다

        */


        nowCapturing = false;
    }
}
