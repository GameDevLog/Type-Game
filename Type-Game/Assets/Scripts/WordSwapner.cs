using System.IO;
using UnityEngine;

public class WordSwapner : MonoBehaviour
{
    public Transform wordTransform;
    private Transform myTransform;
    public TextAsset txt;

    public static WordSwapner instance; 
    private string txtLine;
    public string word; 
    public string explain;
    
    private float interval; 
    private string[] txtData;
    public int midBreak;

    void Start()
    {
        instance = this;
        myTransform = this.transform;

        txtData = txt.text.Split('\n');
    }

    void Update()
    {
        interval -= Time.deltaTime;
        if (interval <= 0)
        {
            txtLine = txtData[Random.Range(0, txtData.Length)];
            word = txtLine.Split('|')[0].TrimEnd();
            explain = txtLine.Split('|')[1].TrimStart();
            Instantiate(wordTransform, new Vector3(myTransform.position.x + Random.Range(-4, 4), myTransform.position.y, myTransform.position.z), Quaternion.identity);
            interval = 3.5f;
        }
    }
}
