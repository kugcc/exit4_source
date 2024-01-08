using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endroll : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float lineSpace;

    [SerializeField]
    TextAsset textAsset;

    [SerializeField]
    GameObject textObj;

    Queue<GameObject> queue = new Queue<GameObject>();

    [SerializeField]
    float upper;

    string[] lines;

    float time_lineDelta;

    bool started = false;
    bool finished = false;

    float startedTime;

    int index = 0;

    void Start()
    {
        screenEffect.instance.drawPannel(0f, Color.black);

        splitText();
        startEndRoll();
    }

    void splitText()
    {
        lines = textAsset.ToString().Split('\n');
    }

    void startEndRoll()
    {
        started = true;
        time_lineDelta = lineSpace * speed * 0.02f;
        startedTime = Time.time;

        queue.Enqueue(genNewText());
    }

    GameObject genNewText()
    {
        GameObject newText = Instantiate(textObj);
        newText.GetComponent<TextMeshPro>().text = lines[index];
        index++;
        return newText;
    }

    void FixedUpdate()
    {
        if (!started)
            return;

        if (index < lines.Length && Time.time > lineSpace / speed + startedTime)
        {
            queue.Enqueue(genNewText());
            startedTime = Time.time;
        }

        List<GameObject> list = new List<GameObject>(queue);
        for (int i = 0; i < list.Count; i++)
        {
            list[i].transform.Translate(0, speed * 0.02f, 0);
            if (list[i].transform.position.y > upper)
            {
                GameObject delText = queue.Dequeue();
                Destroy(delText);
                if (queue.Count == 0)
                {
                    startedTime = Time.time;
                    finished = true;
                }
            }
        }
        if (!finished)
            return;
        screenEffect.instance.drawPannel((Time.time - startedTime / 1f), Color.black);
        if (Time.time - startedTime > 1f)
        {
            StartCoroutine(scm.restartGame(1f));
        }
    }
}
