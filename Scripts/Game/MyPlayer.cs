using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Photon.Pun;



public class MyPlayer : Singleton<MyPlayer>
{
    public static Cihaz cihaz;

    public SpriteRenderer arkaPlan;

    public Text nickName;

    public float MovementDisableDuration;

    public GameObject Goal;

    private PhotonView pv;

    private Rigidbody2D rb;


    private void Awake()
    {
#if UNITY_STANDALONE_WIN

        cihaz = Cihaz.windows;

#endif

#if UNITY_ANDROID

        cihaz = Cihaz.android;

#endif

#if UNITY_EDITOR

        cihaz = Cihaz.unity;

#endif
    }

    private void Start()
    {
        pv = GetComponent<PhotonView>();        
        
        rb = GetComponent<Rigidbody2D>();

    }

    public void DisableMovement()     // bu kadar süre movement engellensin
    {
        GetComponent<Movement>().enabled = false;
        Invoke(nameof(EnableMovement), MovementDisableDuration);
    }

    private void EnableMovement()
    {
        GetComponent<Movement>().enabled = true;
    }

    public void GolLocal()          // sadece gol yiyen cihazda ve kişide çalışır
    {
        Data.gol++;
        pv.RPC(nameof(SetScoreGlobal),RpcTarget.All, Data.playerOrder,Data.gol.ToString());    // oyun içi skoru güncelle
        ScoreBoard.Instance.SetInfosScoreBoardItemsLocal(PhotonNetwork.NickName, 0, Data.gol, Data.playerOrder);  // biri gol yediğinde tüm ekranlarda kendi score boardını güncelleyecek
        AmILose();
    }

    [PunRPC]
    private void SetScoreGlobal(int playerOrder, string score)
    {
        ScoreController.Instance.Scores[playerOrder - 1].GetComponent<Score>().SetScoreLocal(score);
    }


    public void GoFirstSpawnPosition()
    {
        transform.DOLocalMove(PlayerSpawner.spawnPoint, 1).SetEase(Ease.Flash);
        Invoke(nameof(ResetVelocity), 1f);
    }
    
    private void AmILose()
    {
        if(Data.gol == 1)
        {
            Data.amILose = true;     // sona kalan oyuncuyu anlamak için, bir tek sona kalanın değeri true oluyor
            GoalSpawner.localGoal.GetComponent<Goal>().ChangeColorWhenKnockedOutLocal();        // kendi kalesinin rengini kırmızı yapsın
            pv.RPC(nameof(SetScoreGlobal), RpcTarget.All, Data.playerOrder, "K.O");    // oyun içi skoru güncelle
            Room.Instance.DestroyAllInstantinatedObjects();
            MenuManager.Instance.OpenMenu("LostPanel");
            Debug.LogError("Ben Yenildim");
            Room.Instance.IsWinnerBeenLocal();
        }
    }


    

    void ResetVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }

}



public enum Cihaz
{
    unity,
    windows,
    android
}
