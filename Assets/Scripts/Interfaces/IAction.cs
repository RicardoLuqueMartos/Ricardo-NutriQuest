using UnityEngine;

public interface IAction
{
    void VerifyAction();

    void LaunchAction();

    void StopAction();

    void PlayAnimation();

    void StopAnimation();

    void PlayAudio();
}