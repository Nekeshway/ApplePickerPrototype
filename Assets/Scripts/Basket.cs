using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Basket : MonoBehaviour
{
    private TextMeshProUGUI ScoreGT;
    private HighScore _highScore;
    public int amountPoint;
    [SerializeField] private float _sensitivity;

    void Start()
    {
        _highScore = FindObjectOfType<HighScore>();
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        ScoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        ScoreGT.text = "0";
    }

    private void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = Vector3.Lerp(transform.position,pos,_sensitivity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject colliededWith = coll.gameObject;
        if (colliededWith.tag == "Apple")
        {
            Destroy(colliededWith);
            int score = int.Parse(ScoreGT.text);
        score += amountPoint;
        ScoreGT.text = score.ToString();
        if (score > HighScore.score)
        {
            HighScore.score = score;
        }

        _highScore.UpdateScore();
        }
}
    
}
