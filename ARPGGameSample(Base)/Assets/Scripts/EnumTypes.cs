using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumTypes
{
    // 아이템 타입 (무기, 소모품)
    public enum ITEM_TYPE { WP, CB }

    // 무기 타입 (갑옷, 근접 무기)
    public enum WP_TYPE { ARMOR, MELEE }

    // 소모성 아이템 타입 (보석 증가, 체력 증가, 마나 증가)
    public enum CB_TYPE { GEM_UP, HP_UP, MP_UP }
}