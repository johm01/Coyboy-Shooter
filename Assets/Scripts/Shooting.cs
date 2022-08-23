using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBewtweenFire;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

       transform.rotation = Quaternion.Euler(0, 0, rotZ);
        

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBewtweenFire)
            {
                //anim.SetBool("shoot", false);
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            //anim.SetBool("shoot", true);
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            //anim.SetBool("shoot", false);

        }
    }
}
