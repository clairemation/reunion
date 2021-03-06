﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ValueCurve {

	[Serializable]
	public enum CurveType {
		Linear
	}

	[SerializeField] float startVal; 
	[SerializeField] float finishVal;
	[SerializeField] CurveType curveType = CurveType.Linear;

	public float GetValue (float x) {
		float result = -1f;
		switch(curveType){
			case CurveType.Linear:
				result = Lerp(startVal, finishVal, x);
				break;
			default:
				break;
		}

		return result;
	}

	public int GetIntValue (float x) {
		float result = GetValue(x);
		return Mathf.RoundToInt(result);
	}

	float Lerp (float start, float finish, float t) {
		bool reversed = (finish < start);
		return reversed ? ReverseLerp(startVal, finishVal, t) : Mathf.Lerp(startVal, finishVal, t);
	}

	float ReverseLerp(float start, float finish, float t){
		return start - ((start - finish) * t);
	}
}

