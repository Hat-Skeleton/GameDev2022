using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatSO : MonoBehaviour
{
	[SerializeField]
	private float _value;

	public float Value
	{
		get { return _value; }
		set { _value = value; }
	}

}
