using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_Pen : MonoBehaviour
{
    public static bool RayPen = false;
    public Transform FirPen;
    private static int Time_Huo = 0;

    public static bool IO_Huo = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (RayPen)
        {
            _Sys_Main._Hashtable_Find("Steam").SetActive(true);
            Debug.DrawRay(FirPen.position, FirPen.forward * -1 * 1000.0f, Color.blue);

            RaycastHit HitPen;
            if (Physics.Raycast(FirPen.position, FirPen.forward * -1, out HitPen, 1000.0f))
            {
                if (HitPen.collider.gameObject.name == "Flame")
                {
                    Time_Huo += 1;

                    if (Time_Huo >= 100)
                    {
                        _Sys_Main._Hashtable_Find("InnerCore").SetActive(false);

                    }
                    if (Time_Huo >= 200)
                    {
                        _Sys_Main._Hashtable_Find("OuterCore").SetActive(false);

                    }
                    if (Time_Huo >= 300)
                    {
                        _Sys_Main._Hashtable_Find("Lightsource").SetActive(false);
                        IO_Huo = true;

                    }
                    //_Sys_Main._Hashtable_Find("InnerCore").SetActive(false);
                    //_Sys_Main._Hashtable_Find("OuterCore").SetActive(false);
                    //_Sys_Main._Hashtable_Find("Lightsource").SetActive(false);


                    //IO_Huo = true;
                }


            }
            else
            {
                Time_Huo = 0;
            }
        }
        else
        {
            _Sys_Main._Hashtable_Find("Steam").SetActive(false);

        }

    }
}
