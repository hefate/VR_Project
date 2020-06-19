using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class _Sys_Main : MonoBehaviour
{


	private bool _Fire_Keep_b;

	/// <summary>
	/// 识别比例
	/// </summary>
	public float _Reconice;

	/// <summary>
	/// 主哈希表
	/// </summary>
	public static Hashtable _Hashtable;

	/// <summary>
	/// 主Objectg的List
	/// </summary>
	public List<GameObject> _List_Object;



	/// <summary>
	/// 主进程总
	/// </summary>
	public static GameObject _Main_Static;

	/// <summary>
	/// 总协程开关
	/// </summary>
	public static bool _IEnumerator_IO;

	/// <summary>
	/// 剧情停顿
	/// </summary>
	public static bool _Drama_Pause;


	/// <summary>
	/// 水枪形态
	/// </summary>
	public enum _WaterGun_Static_E
	{
		/// <summary>
		/// 直流
		/// </summary>
		_V,
		/// <summary>
		/// 花洒
		/// </summary>
		_W,
		/// <summary>
		/// 喷雾
		/// </summary>
		_S
	}

	public static _WaterGun_Static_E _WaterGun_Static;

    private void Start()
    {
        _Initialization();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void _Initialization()
	{
		DateTime now = DateTime.Now;




		//StopAllCoroutines();
		_Hashtable = new Hashtable();
		//_List_Object = new List<GameObject>();


		_Main_Static = this.gameObject;
		_Fire_Keep_b = false;
		_IEnumerator_IO = true;
		_Drama_Pause = false;

		foreach (var v in _List_Object)
		{
			if (v != null)
			{
				if (!_Hashtable.Contains(v.name))
				{
					_Hashtable.Add(v.name, v);
				}
				else
				{
					Debug.LogError("哈希中已存在KEY[" + v.name + "]");
				}
			}
		}

		GameObject _Temp = _Hashtable_Find("_Trigger");
		for (int i = _Temp.transform.childCount - 1; i > -1; i--)
		{
			GetComponent<Trigger>()._List_Trigger.Add(_Temp.transform.GetChild(i).gameObject);
		}


		_Temp = _Hashtable_Find("_Fire");
		for (int i = _Temp.transform.childCount - 1; i > -1; i--)
		{
			_Hashtable.Add(_Temp.transform.GetChild(i).gameObject.name, _Temp.transform.GetChild(i).gameObject);
			//_Temp.transform.GetChild(i).gameObject.SetActive(false);
		}



	}


	/// <summary>
	/// 哈希添加
	/// </summary>
	/// <param name="_Key"></param>
	/// <param name="_Object"></param>
	public static bool _Hashtable_Add(string _Key, GameObject _Object)
	{
		bool _False = true;
		if (_Hashtable.Contains(_Key))
		{
			Debug.LogError("哈希存在(Key)  " + _Key);
			_False = false;
		}
		if (_Hashtable.ContainsValue(_Object))
		{
			Debug.LogError("哈希存在(object)  " + _Object.name);
			_False = false;
		}

		if (true)
		{
			_Hashtable.Add(_Key, _Object);
		}
		return _False;
	}

	/// <summary>
	/// 哈希查找
	/// </summary>
	/// <param name="_Name"></param>
	/// <returns></returns>
	public static GameObject _Hashtable_Find(string _Name)
	{
		GameObject _Temp = null;
		if (_Hashtable.Contains(_Name))
		{
			_Temp = (GameObject)_Hashtable[_Name];
		}
		else
		{
			Debug.LogError("哈希查找错误，不存在的Key [" + _Name + "]");
		}
		return _Temp;
	}

	
}
