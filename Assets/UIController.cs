﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    //ゲームオーバーテキスト
    private GameObject gameOverText;

    //走行距離テキスト
    private GameObject runLengthText;

    //走った距離
    private float Len = 0;

    //走る速度
    private float speed = 0.03f;

    //ゲームオーバーの判定
    private bool isGameOver=false;

	// Use this for initialization
	void Start () {
        //シーンビューからオブジェクトの実体を検索する
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
		
	}

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false)
        {
            //走った距離を更新する
            this.Len += this.speed;

            //走った距離を表示する
            this.runLengthText.GetComponent<Text>().text = "Distance" + Len.ToString("F2") + "m";
        }

        //ゲームオーバーになった場合
        if (this.isGameOver == true){
            //クリックされたらシーンをロードする（追加）
            if (Input.GetMouseButtonDown(0)){
                //GameSceneを読み込む（追加）
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    public void GameOver(){
        //ゲームオーバーになったときに、画面上にゲームオーバーを表示する
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }
}
