using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public float bounceforce;
    private Rigidbody2D body;
    private Animator ani;
    [SerializeField]
    private AudioSource audiosource;
    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;
    private bool IsAlive;
    private bool didflap;
    void Awake()///ham dung san
    {
        IsAlive = true;
        body = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()//ham dung san dung ham vat li
    {
        birdmove();
    }
    void birdmove()
    {
        if (IsAlive)
        {
            if (didflap)
            {
                didflap = false;
                body.velocity = new Vector2(body.velocity.x, bounceforce);
                audiosource.PlayOneShot(flyClip);
            }
        }
        if (body.velocity.y > 0)
        {
            float angel;
            angel = Mathf.Lerp(0, 90, body.velocity.y / 5);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else if (body.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (body.velocity.y < 0)
        {
            float angel;
            angel = Mathf.Lerp(0, -90, -body.velocity.y / 8);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }
    public void FlapButton()
    {
        didflap = true;
    }
    private void OnTriggerEnter2D(Collider2D target)//co tick is trigger
    {
        if (target.tag == "pipeHoler")
        {
            audiosource.PlayOneShot(pingClip);
        }

    }
 
    private void OnCollisionEnter2D(Collider2D target)    {
        if (target.gameObject.tag == "pipe" || target.gameObject.tag == "ground")
        {
            audiosource.PlayOneShot(diedClip);
            ani.SetTrigger("died");
        }

    }
}
