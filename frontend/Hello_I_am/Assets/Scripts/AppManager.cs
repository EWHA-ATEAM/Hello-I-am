using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    [HideInInspector]
    public int visited; // 첫 방문시 0의 값을 가짐 for guide..
    [HideInInspector]
    public int animal_index = -1; // 선택된 animal의 index
    [HideInInspector]
    public bool alertOpen = false;

    [SerializeField]
    private GameObject _alertPrefab;

    
    private GameObject unconnectionAlert;
    
    // 싱글턴 + 씬 간 이동에도 인스턴스가 파괴되지 않도록 설정
    public static AppManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(this);
    }
    

    private void Start()
    {
        // Visited가 없는경우(첫 방문인경우) 기본값 0 반환
        visited = PlayerPrefs.GetInt("Visited");
        Debug.Log("visited:" + visited);
    }

    private void Update()
    {
        // 인터넷 연결 되었는지 확인
        if (Application.internetReachability == NetworkReachability.NotReachable && !alertOpen)
        {
            alertOpen = true;
            unconnectionAlert = Instantiate(_alertPrefab, GameObject.Find("Canvas").transform);
        }
    }

    public void resetForTest()
    {
        PlayerPrefs.DeleteAll();
        visited = 0;
        Debug.Log("pref 초기화");
        Debug.Log("visited:" + visited);
    }
}
