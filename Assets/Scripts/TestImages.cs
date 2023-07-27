using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestImages : MonoBehaviour
{
    public Image img;
    public Sprite[] sprites;
    public int cnt;

    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
        img.sprite = sprites[cnt];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(cnt<sprites.Length){
                cnt++;
                img.sprite = sprites[cnt];
            }
        }
    }
}
