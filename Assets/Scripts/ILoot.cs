using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoot
{
   bool OpenChest(out KeyType o_key);
}
