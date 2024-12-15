using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveEvent : UnityEvent<Vector2>{}
public class LookEvent : UnityEvent<Vector2>{}

public class AttackMeleeEvent : UnityEvent<bool>{}

public class AttackGunEvent : UnityEvent<Bullet>{}
