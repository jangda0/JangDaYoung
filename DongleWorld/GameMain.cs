namespace DongleWorld
{

    internal class GameProgram
    {
        static void Main(string[] args)
        {
            GameData gameData = new();
            var gameLogic = new GameMtr();
            gameLogic.StartGame();
        }
    }

    public class GameMtr
    {
        public Player _player;
        MenuInfo menuInf = new MenuInfo();
        //Shop shop = new Shop();
        //IntoMenu intoMenu = new IntoMenu();


        private bool _isGameOver = false;
        public void StartGame()
        {
            Init();

            while (!_isGameOver)
            {
                InputHandler();
            }

            Console.WriteLine("0게임이 종료되었습니다.");
        }

        private void InputHandler()
        {
            var input = Console.ReadKey();
            _isGameOver = (input.Key == ConsoleKey.Escape); //? true : false; 생략가능.
        }
        private void Init()
        {
            Console.WriteLine("동글 마을에 오신 여러분 환영합니다! ");

            bool isSuccess;
            //닉네임 설정
            while (true)
            {
                Console.WriteLine("닉네임을 입력해주세요.(3~10글자) \n");
                string? playerName = Console.ReadLine();
                {
                    _player = new Player(playerName);
                    //shop._player = _player;
                    if (2 < playerName.Length && playerName.Length < 11)
                    {
                        Console.WriteLine("\n어서오세요 " + playerName + "님!  \n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("닉네임을 다시 입력해주세요.");
                        System.Threading.Thread.Sleep(1500);
                    }
                }
            }

            Console.WriteLine("직업을 선택해주세요.\n\n1.요리사 \n2.건축가 \n3.나무꾼\n");

            //직업 선택
            while (true)
            {
                int job = int.Parse(Console.ReadLine());

                if (0 < job && job < 4)
                {
                    _player.job = (Job)job;
                    Console.WriteLine($"\n{(Job)job}을 선택하셨습니다.\n");
                    Console.WriteLine("마을로 진입합니다...");
                    System.Threading.Thread.Sleep(1000);
                    menuInf.Run(_player);
                    break;
                }
                else
                {
                    Console.WriteLine("직업을 다시 설정해주세요.");
                    System.Threading.Thread.Sleep(1000);
                }
            }


            Console.WriteLine("\n 모험을 마치겠습니까? ");


            //BlinkCursor(); // 마지막 커서 깜빡이기

            Console.ReadLine(); // 입력 대기
            //}

            // 한 글자씩 출력 후, 1초 대기  //너희는 과제 다하면... 살려줄게...
            //static void PrintLineWithDelay(string message)
            //{
            //    foreach (char c in message)
            //    {
            //        Console.Write(c);
            //        Thread.Sleep(50); // 글자 출력 속도
            //    }
            //    Console.WriteLine();
            //    Thread.Sleep(500); // 문장 끝나고 1초 대기
            //}

            //// 깜빡이는 커서 출력 함수
            //static void BlinkCursor()
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.Write("_");
            //        Thread.Sleep(400);
            //        Console.Write("\b \b");
            //        Thread.Sleep(400);
            //    }
            //}
        }
    }

    public class MenuInfo
    {
        IntoMenu intoMenu = new IntoMenu();

        public void Run(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("마을에 오신 걸 환영합니다. \n");
                Console.WriteLine("1.상태창 \n2.인벤토리 \n3.상점 \n\n원하는 행동을 입력해주세요:\n");
                intoMenu.IntoMenuRun(player);
                continue;//다른곳에서 나오면 다시 마을로 돌아오기.
            }
        }
    }

    public class IntoMenu
    {
        Shop shop = new Shop();
        Inven inven = new Inven();
        //Player player = new Player();
        public void IntoMenuRun(Player player)
        {
            while (true) //너무 while문만... 쓴걸까... ㅜㅠ 근데 이거 말고는 생각이 안나는걸....
            {
                int menu = int.Parse(Console.ReadLine());

                switch ((Menu)menu)
                {
                    case Menu.상태창://case 상태창 텍스트가 긴거 같아서 아래로 빼봤드아아아아 >~< 
                        Console.WriteLine($"\n상태창으로 이동합니다.");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    case Menu.인벤토리:
                        Console.WriteLine($"\n인벤토리로 이동합니다.");
                        System.Threading.Thread.Sleep(1000);
                        inven.InvenInfo();
                        break;
                    case Menu.상점:
                        Console.WriteLine($"\n상점으로 이동합니다.");
                        System.Threading.Thread.Sleep(1000);
                        shop.ShopInfo();
                        break;
                    //case Menu.던전:
                    //    PrintLineWithDelay($"\n던전으로 이동합니다.");
                    //    break;
                    default:
                        Console.WriteLine("선택지에 알맞은 번호를 선택해주세요.");
                        System.Threading.Thread.Sleep(1000);
                        continue;
                }
                break;
            }
        }

    }
    public class Player
    {
        public string name;
        public Job job;
        public int hp;
        public int str;
        public int def;
        public int gold;


        public Player(string name)
        {
            this.name = name;
            hp = 100;
            str = 10;
            def = 10;
            gold = 10000;
        }

        public void PlayerInfo()
        {
            while (true)
            {
                Console.WriteLine($"  <<상태창>> \n\n플레이어: {name}\n  직업  : {job}");
                Console.WriteLine($"  체력  : {hp}\n 공격력 : {str}\n 방어력 : {def}\n  Gold  : {gold}");
                Console.WriteLine("\n\nEnter: 마을로 되돌아가기!!");
                Console.WriteLine();
                System.Threading.Thread.Sleep(1000);
                break;
            }
        }
    }

    public class Item
    {
        //public string Item;
        public int Item_n { get; set; }//넘버
        public string Item_ { get; set; }//아이템
        public string Item_st { get; set; }//스탯 종류
        public int Item_sv { get; set; }//스텟밸류
        public string Item_inf { get; set; }//아이템 정보
        public int Price { get; set; }//가격
        public bool IsBuy { get; set; }//판매여부
        public string ItemType { get; set; }//착용부위
        public bool IsEquip { get; set; }//아이템 착장

        public Item(int item_n, string _item, string item_st, int item_sv, string item_inf, int price, bool isBuy, string itemType, bool isEquip)
        {

            Item_n = item_n;
            Item_ = _item;
            Item_st = item_st;
            Item_sv = item_sv;
            Item_inf = item_inf;
            Price = price;
            IsBuy = isBuy;
            ItemType = itemType;
            IsEquip = isEquip;
        }

        //public void Purchase() // 원래 구상하던거... 상점에서 물건 구매하면... Price가 구매완료로 뜨게 하려고 했는데...ㅜㅠ 
        //{
        //    Price = "구매완료"; // 판매금액 정수로 입력해서.. 바꾸면서 보류...
        //    IsBuy = true;
        //}

        public void DrawItemText()
        {
            Console.WriteLine($"{Item_n} [{Item_}] | {Item_st} + {Item_sv} | {Item_inf}");
        }

        public void DrawItemShopPrice()
        {
            Console.WriteLine($"{Item_n} [{Item_}] | {Item_st} + {Item_sv} | {Item_inf} | {Price}");
        }

        public void DrawItemShopBuy()
        {
            Console.WriteLine($"{Item_n} [{Item_}] | {Item_st} + {Item_sv} | {Item_inf} | ", "구매완료");
        }

        public void ItemIven()
        {
            Console.WriteLine();
        }
    }

    class Inven
    {
        string _wear;

        public void InvenInfo()
        {
                Console.Clear();
                Console.Write("<<인벤토리>> ");
                Console.Write(_wear);
                Console.WriteLine("\n\n보유중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("\n\n[아이템 목록] \n\n보유중인 아이템을 관리할 수 있습니다. ");
                Console.WriteLine($"\n\n1.아이템 장착관리 \n0.나가기\n");
                while (true)
                {
                    int choose = int.Parse(Console.ReadLine());

                    switch (choose)
                    {
                        case 0://나가기
                            _wear = "";
                            break;
                        case 1:
                            _wear = " - 아이템 장착관리 \n";
                            InvenInfo();
                            break;
                    }
                    break;
                }
        }
    }


    public class Shop
    {
        //public Player _player;
        //ItemDB ItemDB = new ItemDB();
        //public string _num1;
        //public string _num2;
        //public string _num3;
        string _st;
        bool _istrade;


        public void ShopInfo()
        {
            Console.Clear();
            Console.Write($"<<상점>>");
            Console.Write(_st);
            Console.WriteLine($"\n\n상점에 오신 걸 환영합니다.");
            //Console.WriteLine($"\n\n[보유골드] \n{_player.gold} G\n\n");
            Console.WriteLine($"[아이템 목록]");
            for (int i = 1; i < 11; i++)
            {
                Item item = GameData.Instance.itemDB.Get(i);
                if (_istrade)
                {
                    item.DrawItemShopPrice();
                }
                else
                {
                    item.DrawItemText();
                }
            }
            Console.WriteLine($"\n\n1.아이템 구매 \n2.아이템 판매 \n0.나가기\n");
            //GetMenuInfo(out _num1, out _num2, out _num3); 강의에 나온거 써서 각 페이지마다 선택지 다르게 나오게 하기.. 였는데 실패했다... 
            //Console.WriteLine($"\n1.{_num1} \n2.{_num2} \n0.{_num3}");  예: 상점에선 항목이 1.아이템구매, 2.아이템판매, 3.나가기 /  상태창에선 0.나가기 만 나오게 하기.. 대실패 ㅜㅠ 
            while (true)
            {
                int choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 0://나가기
                        _st = "";
                        _istrade = false;
                        break;
                    case 1:
                        _st = " - 아이템 구매 \n";
                        _istrade = true;
                        ShopInfo();
                        break;
                    case 2:
                        _st = "";
                        _istrade = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"아이템 판매는 단장중 ~★ .★ ~\n");
                        Console.WriteLine($"마을로 되돌아갑니당 ~★ .★ ~");
                        Console.ResetColor();
                        System.Threading.Thread.Sleep(2000);
                        break;
                }
                break;
            }
            //void GetMenuInfo(out string _num1, out string _num2, out string _num3)
            //{
            //    _num1 = "아이템 구매";
            //    _num2 = "아이템 판매";
            //    _num3 = "나가기";
            //} 
        }
    }

    public enum Job
    {
        요리사 = 1,
        건축가,
        나무꾼
    }

    public enum Menu
    {
        상태창 = 1,
        인벤토리,
        상점,
        던전
    }
}

