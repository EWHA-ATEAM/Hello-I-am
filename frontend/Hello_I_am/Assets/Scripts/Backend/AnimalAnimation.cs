using System.Collections;
using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    private ServerCommunicate serverCommunicate;
    private Animator animal;

    private float timer;
    private float intervalTime = 10.0f;

    private int maxAnimNum;

    private void Start()
    {
        timer = 0.0f;
        serverCommunicate = GameObject.Find("Canvas").GetComponent<ServerCommunicate>();
        animal = GetComponent<Animator>();

        // 랜덤 애니메이션을 위한 최대 애니메이션 값 추가
        if (AppManager.instance.animal_index == 0) maxAnimNum = 4;  // polarbear
        else if (AppManager.instance.animal_index == 0) maxAnimNum = 6; // redpanda
        else if (AppManager.instance.animal_index == 0) maxAnimNum = 3; // snow leopard
    }

    private void Update()
    {
        if (serverCommunicate.receiveMotion)
        {
            serverCommunicate.receiveMotion = false;
            int motion = serverCommunicate.motionIndex;
            Debug.Log(motion);

            if(motion == 0) // heart
            {
                animal.SetTrigger("heartTrigger");
            }
            else if(motion == 1) // hi
            {
                animal.SetTrigger("hiTrigger");
            }
            else if(motion == 2) // pet
            {
                animal.SetTrigger("petTrigger");
            }
        }
        else
        {
            // 랜덤으로 애니메이션 재생되면 재밌을듯
            if (animal.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                timer += Time.deltaTime;

                if (timer > intervalTime)
                {
                    timer = 0;

                    string animName = "randomTrigger" + Random.Range(0, maxAnimNum);
                    animal.SetTrigger(animName);
                }
            }
        }
    }

    public void onClickTest()
    {
        animal.SetTrigger("petTrigger");
    }
}
