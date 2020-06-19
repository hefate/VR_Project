using UnityEngine;
using System.Collections;

public class TapControl : MonoBehaviour {

    bool _isOn = false;
    public bool isOn 
    {
        get { return _isOn; }
        set 
        {
            _isOn = value;
            if (_isOn)
            {
                mAnimation["sink01_tap_animator"].speed = 1;
                water.SetActive(_isOn);
            }
            else
            {
                mAnimation["sink01_tap_animator"].time = mAnimation["sink01_tap_animator"].clip.length;
                mAnimation["sink01_tap_animator"].speed = -1;
                StartCoroutine(DelaySetWater(false));
            }
            mAnimation.Play("sink01_tap_animator");
        }
    }
    public GameObject water;
    private Animation mAnimation;
    void Start()
    {
        mAnimation = this.GetComponent<Animation>();
    }
    IEnumerator DelaySetWater(bool isOn)
    {
        yield return new WaitForSeconds(0.5f);
        water.SetActive(isOn);
    }
}
