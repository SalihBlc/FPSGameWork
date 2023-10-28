using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using TMPro;



public class ZombieMovement : MonoBehaviour
{
    NavMeshAgent nav;

    Animator anim;
    [SerializeField] float ZombieHealth = 100;
    public GameObject target;
    public float AttackArea = 2f;
    public AudioClip zombieVoice;
    AudioSource zombieSoundSource;





    public float offset = 0f;
    //public TextMeshProUGUI zombieOffsetText;


    void Start()
    {

        anim = GameObject.Find("Parasite L Starkie").GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        zombieSoundSource = this.gameObject.GetComponent<AudioSource>();



        // zombieOffsetText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ZombieFollow();


    }

    public void TakeDamage()
    {
        ZombieHealth -= UnityEngine.Random.Range(1, 4);

        if (ZombieHealth < 1)
        {
            anim.SetBool("Death", true);
            StartCoroutine(ZombieDeathDestroy());

        }


    }
    IEnumerator ZombieDeathDestroy()

    {
        yield return new WaitForSeconds(8);
        Destroy(this.gameObject);
    }

    void ZombieFollow()
    {
        //        zombieOffsetText.text = offset.ToString();
        offset = Vector3.Distance(this.transform.position, target.transform.position);


        if (offset < 20)
        {
            nav.isStopped = false;
            nav.SetDestination(target.transform.position);
            anim.SetBool("Run", true);
            anim.SetBool("Attack", false);
            this.gameObject.transform.LookAt(target.transform.position);



        }
        else
        {
            nav.isStopped = true;
            anim.SetBool("Run", false);
            anim.SetBool("Attack", false);
        }
        if (offset < AttackArea)
        {
            nav.isStopped = true;
            anim.SetBool("Attack", true);
            anim.SetBool("Run", false);
            this.gameObject.transform.LookAt(target.transform.position);


        }

    }
    public void zombieVoie()
    {
        zombieSoundSource.PlayOneShot(zombieVoice);

    }
    void CharacterHasarVer()
    {
        target.GetComponent<CharacterMovement>().CharacterHasarAl();
    }
}
