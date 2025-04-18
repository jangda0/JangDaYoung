using DongleWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DongleWorld.GameMtr;

public class ItemDB
{
    Dictionary<int, Item> items = new Dictionary<int, Item>();
    public ItemDB()
    {
        items.Add(1, new Item(1, "후라이팬", "공격력", 10, "무쇠로 만든 튼튼한 후라이팬입니다.", 1000, false, "무기", false));
        items.Add(2, new Item(2, "앞치마", "방어력", 10, "우레탄으로 만들어져 방수가 기능이 포함된 앞치마입니다.", 1000, false, "망토", false));
        items.Add(3, new Item(3, "앞치마", "방어력", 5, "캔버스으로 만든 예쁜 앞치마입니다.", 2000, false, "망토", false));
        items.Add(4, new Item(4, "두건", "방어력", 5, "순면으로 만든 예쁜 두건니다.", 1000, false, "모자", false));
        items.Add(5, new Item(5, "안전모", "방어력", 10, "머리를 보호하는 튼튼한 안전모입니다.", 1000, false, "모자", false));
        items.Add(6, new Item(6, "줄자", "공격력", 10, "길이가 늘어나는 줄자입니다.", 1000, false, "무기", false));
        items.Add(7, new Item(7, "무쇠도끼", "공격력", 10, "순면으로 만든 튼튼한 도끼입니다.", 1000, false, "무기", false));
        items.Add(8, new Item(8, "장화", "방어력", 5, "우레탄으로 만든 방수 기능이 있는 신발입니다.", 1000, false, "신발", false));
        items.Add(9, new Item(9, "작업복", "방어력", 10, "작업할때 편하게 입는 의상입니다.", 1000, false, "옷", false));
        items.Add(10, new Item(10, "목장갑", "방어력", 5, "작업할때 편하게 쓰는 장갑입니다.", 1000, false, "장갑", false));
    }

    public Item Get(int key)
    {
        if (items.ContainsKey(key))
        {
            return items[key];
        }
        return null;
    }
}

