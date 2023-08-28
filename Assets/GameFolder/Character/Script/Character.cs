using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int life;
    public Transform Skin;
    public Transform Cam;
    public Text heartCountText;
    public Transform Heart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        heartCountText.text = "x" + life.ToString();

        if (life <= 5 && life > 0)
        {
            Heart.GetComponent<Animator>().Play("HeartWarning");
        }

        if (life <= 0)
        {
            Skin.GetComponent<Animator>().Play("Die");
            heartCountText.text = "x0";
            Heart.GetComponent<Animator>().Play("HeartDead");

        }

        
        
       
    }
    public void PlayerDamege(int value)
    {
        life = life - value;
        Skin.GetComponent<Animator>().Play("PlayerDamage", 1);
        Cam.GetComponent<Animator>().Play("CamPlayerDamge", - 1);
    }

}
