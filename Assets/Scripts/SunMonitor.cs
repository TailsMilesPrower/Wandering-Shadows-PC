using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SunMonitor : MonoBehaviour
{
    private float _nextTimeTimerTriggers = 0f;

    public LayerMask mask;
    public Light dirLight;
    private Vector3 oppositeDirection;
    private Renderer playerRenderer;


    private bool _isCausingDamage = false;
    public float DamageRepeatRate = 0.3f;
    public int DamageAmount = 1;
    public bool Repeating = true;
    public bool isHiding;
    
    
    //SOUNDS
    [SerializeField] private float sunRraycastHightFactor = 1f;

    //[SerializeField] private AudioClip burningSoundClip;

    AudioSource burningSoundSource;
    //bool sFX_Play;



    private void Awake()
    {
        _nextTimeTimerTriggers = Time.realtimeSinceStartup + DamageRepeatRate;
    }




    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        burningSoundSource = GetComponent<AudioSource>();
        //sFX_Play = false;
        //burningSoundSource.Stop();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        oppositeDirection = -1f * dirLight.transform.forward;
        // Debug.Log(oppositeDirection.ToString());

        if (Physics.Raycast(transform.position+ Vector3.up * sunRraycastHightFactor, oppositeDirection, 100f, mask)) {
           // Debug.DrawRay(transform.position, oppositeDirection * hit.distance, Color.green);
            playerRenderer.material.color = Color.green;

            //sFX_Play = false;
            //burningSoundSource.Stop();
            burningSoundSource.Play();
            //No Dmg from sun
            {
                PlayerController player = gameObject.GetComponent<PlayerController>();
                if (player != null)
                {
                    
                    isHiding = true;
                    _isCausingDamage = false;
                }
            }

        } else 
        {
            Debug.DrawRay(transform.position, oppositeDirection * 50f, Color.red);
            playerRenderer.material.color= Color.red;

            //sFX_Play = true;
            //burningSoundSource.Play();


            //Dmg from sun
            {
                isHiding = false;
                _isCausingDamage = true;
                PlayerController player = gameObject.GetComponent<PlayerController>();
                //SoundEffectManager.instance.PlaySoundFXClip(burningSoundClip, transform, 1f);


                if (player != null)
                {
                    

                    if (_isCausingDamage && _nextTimeTimerTriggers < Time.realtimeSinceStartup)
                    {
                        
                            // Do the thing!
                        TakeDamage(player, DamageRepeatRate);

                            _nextTimeTimerTriggers = Time.realtimeSinceStartup + DamageRepeatRate;

                        /*audioSource.clip = damageSoundClip;
                        audioSource.Play();*/
                    }
                }
            }
        }
    }

    private void TakeDamage(PlayerController player, float repeatRate)
    {
        repeatRate = DamageRepeatRate;
        player.TakeDamage(DamageAmount);

        //burning soundeffect
        //SoundEffectManager.instance.PlaySoundFXClip(burningSoundClip, transform, 1f);

        if (player.IsDead)
            _isCausingDamage = false;
    }
}
