using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    [SerializeField]
    int CurLocation = 0; //現在位置（看板の番号）

    [SerializeField]
    int goalLocation = 8;

    public int curLoc
    {
        get { return CurLocation; }
    }
    public int goalLoc
    {
        get { return goalLocation; }
    }

    [SerializeField]
    Transform startPosition;
    public actorController player;

    float startedTime;

    [SerializeField]
    Transform lastPsg;

    [SerializeField]
    GameObject goalPsg;

    [SerializeField]
    GameObject normalPsg;

    [SerializeField]
    GameObject[] anrmlPsg;

    KeyCode[] konamiCode = { KeyCode.T, KeyCode.O,KeyCode.K, KeyCode.I,KeyCode.Z, KeyCode.G};
    int currentIndex = 0;

    [SerializeField]bool isInFindGame;
    public bool isFGame
    {
        get { return isInFindGame; }
    }
    bool isAnrml;

    public void Awake()
    {
        instance = this;
        isInFindGame = false;
    }

    void Start()
    {
        startedTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startedTime < 1f)
            screenEffect.instance.drawPannel(1f - (Time.time - startedTime / 1f), Color.black);


        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(konamiCode[currentIndex]))
            {
                currentIndex++;
                if (currentIndex == konamiCode.Length)
                {
                    // コナミコマンドが完了した時の処理をここに追加
                    scm.serclet();
                    currentIndex = 0;  // リセットして再度入力可能にする
                }
            }
            else
            {
                // 間違ったキーが押された時の処理をここに追加
                currentIndex = 0;  // リセット
            }
        }
    }

    public void answer(bool ans, Vector3 diff)
    {
        if (ans == isAnrml)
        {
            CurLocation++;
        }
        else
        {
            CurLocation = 0;
        }
        setPlayerPos(ans, diff);
        initPassage();
        isInFindGame = false;
    }

    public void loop(Vector3 pos)
    {
        CurLocation = 0;
        player.teleport(pos, 0f);
    }

    void setPlayerPos(bool ans, Vector3 diff)
    {
        if (ans)
        {
            player.teleport(startPosition.position - diff, 180f);
        }
        else
        {
            player.teleport(startPosition.position + diff, 0f);
        }
    }

    GameObject setNewPassage()
    {
        isAnrml = false;
        GameObject nextRoad = normalPsg;

        float r = Random.Range(0, 100);
        Debug.Log(r);
        //異常 or 通常
        if (r >= 50)
        {
            int randomIdx = Random.Range(0, anrmlPsg.Length);
            nextRoad = anrmlPsg[randomIdx];
            isAnrml = true;
        }

        //ゴール or notゴール
        if (CurLocation >= goalLocation)
        {
            float genGoal = Random.Range(0, 100);
            Debug.Log(genGoal);

            if (genGoal >= 50)
            {
                nextRoad = goalPsg;
            }
        }
        return nextRoad;
    }

    public void generateNewPassage()
    {
        Destroy(lastPsg.gameObject);
        lastPsg = GameObject.Instantiate(setNewPassage()).transform;
        isInFindGame = true;
    }

    public void initPassage()
    {
        Destroy(lastPsg.gameObject);
        lastPsg = GameObject.Instantiate(normalPsg).transform;
    }
}
