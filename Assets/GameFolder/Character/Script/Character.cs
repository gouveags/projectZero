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
       

        if (life <= 5 && life > 1)
        {
            Heart.GetComponent<Animator>().Play("HeartWarning", -1);
        }
        else

        if (life <= 0)
        {
         
            
            Skin.GetComponent<Animator>().Play("Die", -1);
            Heart.GetComponent<Animator>().Play("HeartDead", -1);
            life = 0;

        }

        heartCountText.text = "x" + life.ToString();

    }
    
    public void PlayerDamege(int value)
    {
        life = life - value;
        Skin.GetComponent<Animator>().Play("PlayerDamage", 1);
        Cam.GetComponent<Animator>().Play("CamPlayerDamge", - 1);
    }

}
