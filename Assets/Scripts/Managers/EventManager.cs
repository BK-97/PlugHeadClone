using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{ 

}

public class IntEvent : UnityEvent<int> { }
public class StringEvent : UnityEvent<string> { }
public class GameObjectEvent : UnityEvent<GameObject> { }
public class BoolEvent : UnityEvent<bool> { }
