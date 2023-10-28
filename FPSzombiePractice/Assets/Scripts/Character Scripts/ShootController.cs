using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Animations;

public class ShootController : MonoBehaviour
{
    Ray ray;
    public Camera kamera;
    public LayerMask zombiLayer;
    Animator anim;
    CharacterMovement charMove;
    public ParticleSystem muzzle;
    private float sarzor = 200;
    private float cephane = 20;
    private float kapasite = 5;
    AudioSource sesKaynagi;
    public AudioClip gunShoot;
    public AudioClip reloadShoot;



    void Start()
    {
        anim = GameObject.Find("Whiteclown N Hallin").GetComponent<Animator>();
        kamera = Camera.main;
        charMove = GameObject.Find("Whiteclown N Hallin").GetComponent<CharacterMovement>();
        // muzzle = GameObject.Find("Muzzle").GetComponent<ParticleSystem>();
        sesKaynagi = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //ShootRay();
        if (charMove.Aliveİs() == false)
        {
            if (Input.GetMouseButton(0))
            {

                if (sarzor > 0)
                {
                    anim.SetBool("Shoot", true);

                }
                if (sarzor <= 0)
                {
                    //   anim.SetBool("Reload", true);
                    anim.SetBool("Shoot", false);
                    muzzle.Stop();
                }
                if (sarzor <= 0 && cephane > 0)
                {


                    anim.SetBool("Reload", true);

                }

            }
            else
            {
                anim.SetBool("Shoot", false);
                muzzle.Stop();
            }
        }
        /* if (Input.GetKey(KeyCode.R))
         {
             SarzorDegistirme();
         }*/


    }
    public void SarzorDegistirmeSes()
    {
        sesKaynagi.PlayOneShot(reloadShoot);

    }
    public void SarzorDegistirme()
    {
        cephane -= kapasite - sarzor;
        sarzor = kapasite;
        anim.SetBool("Reload", false);
    }
    public void ShootRay()
    {
        if (sarzor > 0)
        {
            sarzor--;
            muzzle.Play();
            sesKaynagi.PlayOneShot(gunShoot);
            ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, zombiLayer))
            {
                // zombieScirpt.ZombieController();
                Debug.DrawLine(transform.position, hit.point, Color.green);

                hit.collider.gameObject.GetComponent<ZombieMovement>().TakeDamage();
            }
        }

    }
    public float GetSarzor()
    {
        return sarzor;
    }
    public float GetCephane()
    {
        return cephane;
    }
}
