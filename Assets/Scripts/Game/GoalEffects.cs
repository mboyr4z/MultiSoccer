using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Photon.Pun;

public class GoalEffects : Singleton<GoalEffects>
{

    public GameObject goalText;

    public GameObject badGoalKeeper;

    [SerializeField] private AbstractGoalTextEffectStyle abstractGoalTextEffectStyle;

    [SerializeField] private AbstractBadGoalKeeperEffectStyle abstractBadGoalKeeperEffectStyle;

    [SerializeField] private float GoalTextEffectWaitingTime;

    [SerializeField] private float BadGoalKeeperEffectWaitingTime;

    public void StartGoalTextEffect()
    {
        abstractGoalTextEffectStyle.GoalTextEffects(goalText);
        Invoke("StopGoalTextEffect",GoalTextEffectWaitingTime);
    }

    private void StopGoalTextEffect()
    {
        abstractGoalTextEffectStyle.Stop();
        goalText.transform.localScale = Vector3.zero;
    }

    public void StartBadGoalKeeperEffectLocal(string nickName)
    {
        GetComponent<PhotonView>().RPC("StartBadGoalKeeperEffectGlobal", RpcTarget.All, nickName);
    }

    [PunRPC]
    public void StartBadGoalKeeperEffectGlobal(string nickName )
    {
        badGoalKeeper.GetComponent<Text>().text = nickName;
        abstractBadGoalKeeperEffectStyle.BadGoalKeeperTextEffect_first(badGoalKeeper);
        Invoke("SecondBadGoalKeeperEffect", BadGoalKeeperEffectWaitingTime);
    }

    private void SecondBadGoalKeeperEffect()
    {
        abstractBadGoalKeeperEffectStyle.BadGoalKeeperTextEffect_second(badGoalKeeper);
    }





}
