using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Observer : MonoBehaviour
{
    #region KEYS
    public static string GAME_START = "GameStart";
    #endregion

    private static Observer _instant;
    public static Observer Instant => _instant;

    Dictionary<string, List<Action<object>>> _listActions = new Dictionary<string, List<Action<object>>>();
    

    private void Awake()
    {
        _instant = this;
    }


    public void AddListener(string key, Action<object> callBack) {
        List<Action<object>> tmpActions = new List<Action<object>>();
        if (_listActions.ContainsKey(key)) {
            tmpActions = _listActions[key];
        }
        else {
            _listActions.Add(key, tmpActions);
        }

        tmpActions.Add(callBack);
    }

    public void Notify(string key, object data = null) {
        
        if (!_listActions.ContainsKey(key)) {
            return;
        }

        foreach (Action<object> action in _listActions[key]) {
            action?.Invoke(data);
        }
       
    }
}
