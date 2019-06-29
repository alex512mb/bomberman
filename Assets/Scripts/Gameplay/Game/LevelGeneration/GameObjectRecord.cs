using System;
using UnityEngine;

public class GameObjectRecord<TypeEnum> where TypeEnum : Enum
{
    public TypeEnum id;
    public Vector2 pos;
}

