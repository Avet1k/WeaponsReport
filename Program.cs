namespace WeaponsReport;
class Program
{
    static void Main(string[] args)
    {
        List<Soldier> soldiers = new List<Soldier>
        {
            new ("Данилова А.Я."),
            new ("Волкова Е.Д."),
            new ("Савельева Е.С."),
            new ("Никитина К.А."),
            new ("Попова С.М."),
            new ("Васильева А.О."),
            new ("Тихонова В.Т."),
            new ("Ефимова С.Ю."),
            new ("Карпов З.Д."),
            new ("Сомов А.А.")
        };

        Squad squad = new Squad(soldiers);
        
        squad.ShowFullInfo();
        Console.WriteLine();
        squad.ShowLessInfo();
    }
}

class Soldier
{
    private static string[] _weapons = { "штурмовая винтовка", "марксманская винтовка", "пулемёт", "пистолет-пулемёт" };
    private static string[] _ranks = { "рядовой", "младший сержант", "ефрейтор" };

    public Soldier(string name)
    {
        Random random = new Random();
        int minTerm = 1;
        int maxTerm = 25;

        Name = name;
        Weapon = _weapons[random.Next(_weapons.Length)];
        Rank = _ranks[random.Next(_ranks.Length)];
        ServiceTerm = random.Next(minTerm, maxTerm);
    }
    
    public string Name { get; private set; }
    public string Weapon { get; private set; }
    public string Rank { get; private set; }
    public int ServiceTerm { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name} Оружие: {Weapon}. Звание: {Rank}. Срок службы: {ServiceTerm} мес.");
    }
}

class Squad
{
    private List<Soldier> _soldiers;

    public Squad(List<Soldier> soldiers)
    {
        _soldiers = soldiers;
    }

    public void ShowFullInfo()
    {
        Console.WriteLine("Полная информация об отряде:\n");

        foreach (Soldier soldier in _soldiers)
            soldier.ShowInfo();
    }

    public void ShowLessInfo()
    {
        var soldiers = _soldiers.Select(soldier => new { soldier.Name, soldier.Rank });
        
        Console.WriteLine("Краткая информация об отряде (ФИО - звание):\n");
        
        foreach (var soldier in soldiers)
            Console.WriteLine($"{soldier.Name} - {soldier.Rank}");
    }
}
