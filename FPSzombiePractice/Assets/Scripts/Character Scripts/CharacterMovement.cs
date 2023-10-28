using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator anim;
    float characterSpeed = 3f;
    float characterJumpPower = 6f;

    float MoveH;
    float MoveV;
    float MoveJump;
    public float CharacterHealth = 50f;
    public bool İsDeath;
    ZombieMovement shootStop;
    void Start()
    {
        anim = GetComponent<Animator>();
        İsDeath = false;
        shootStop = gameObject.GetComponent<ZombieMovement>();
    }
    public float GetHP()
    {
        return CharacterHealth;
    }

    void Update()
    {
        İsAliveOrDeath();

    }
    public void İsAliveOrDeath()
    {
        if (CharacterHealth < 1)
        {
            İsDeath = true;
            anim.SetBool("DeathCh", true);


        }
        else if (İsDeath == false)
        {


            CharacterMove();

        }
    }
    public bool Aliveİs()
    {
        return İsDeath;
    }
    public void CharacterMove()
    {
        MoveH = Input.GetAxis("Horizontal");
        MoveV = Input.GetAxis("Vertical");
        MoveJump = Input.GetAxis("Jump");
        transform.Translate(MoveH * characterSpeed * Time.deltaTime, MoveJump * characterJumpPower * Time.deltaTime, MoveV * characterSpeed * Time.deltaTime);
        anim.SetFloat("Horizontal", MoveH);
        anim.SetFloat("Vertical", MoveV);
    }
    public void CharacterHasarAl()
    {
        CharacterHealth -= Random.Range(4, 8);

    }
}
