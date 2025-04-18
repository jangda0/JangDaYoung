using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GameData
{
    public static GameData Instance;//싱글톤패턴
    public ItemDB itemDB;

    public GameData()
    {
        itemDB = new ItemDB();
        Instance = this;

    }
}