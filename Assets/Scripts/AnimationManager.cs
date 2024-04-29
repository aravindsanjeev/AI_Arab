using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    
    void OnStartTalking()
    {
        currentIndex = GetRandomNumberExcluding(1,4,currentIndex);
        print("######################################### ="+currentIndex);
        animator.SetInteger("Id", currentIndex);
        //animator.SetInteger("Id", 2);
    }

    void OnStartSinging()
    {
        animator.SetInteger("Id", 4);
        //animator.SetInteger("Id", 2);
    }

    public void OnCallBackAudioStarted(UnityEngine.Object obj)
    {
        AnimIndicator ind = (AnimIndicator)obj;
        if (ind.index == 1)
            OnStartTalking();
        else if (ind.index == 2)
            OnStartSinging();
    }

    public void OnStopTalking()
    {
        animator.SetInteger("Id", 0);
    }

    //-----Random from 3
    int currentIndex = 0;

    int GetRandomNumberExcluding(int min, int max, int excludedValue)
    {
        int randomValue;
        do
        {
            randomValue = Random.Range(min, max);
        } while (randomValue == excludedValue);

        return randomValue;
    }
}

//0 => stop, 1 => talk, 2 => song
public class AnimIndicator : MonoBehaviour
{
    public int index;
}
