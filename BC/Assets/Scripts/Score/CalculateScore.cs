using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateScore : MonoBehaviour
{
    public Text enemyCount;
    public int Tier;
    private string count;


    // Start is called before the first frame update
    void Start()
    {
        count = enemyCount.text;
        int.Parse(count);
    }

    // Update is called once per frame
    void Update()
    {
        count = enemyCount.text;
        GetComponent<Text>().text = (int.Parse(count)*Tier).ToString();
    } 
}
