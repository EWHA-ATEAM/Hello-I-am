using System.Collections;
using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    private ServerCommunicate serverCommunicate;
    private Animator animal;

    private void Start()
    {
        serverCommunicate = GameObject.Find("Canvas").GetComponent<ServerCommunicate>();
        animal = GetComponent<Animator>();
    }

    private void Update()
    {
        if (serverCommunicate.receiveMotion)
        {
            serverCommunicate.receiveMotion = false;
            int motion = serverCommunicate.motionIndex;

            if(motion == 0) // hi
            {
                animal.SetTrigger("hiTrigger");
            }
            else if(motion == 1) // heart
            {
                animal.SetTrigger("heartTrigger");
            }
            else if(motion == 2) // pet
            {
                animal.SetTrigger("petTrigger");
            }
        }
        else
        {
            // 랜덤으로 애니메이션 재생되면 재밌을듯
        }
    }

    public void onClickTest()
    {
        animal.SetTrigger("petTrigger");
    }
}
