namespace Dependency_Injection.Models
{
    public enum Gender
    {
        Male=0,
        Female
    }
    public enum HairColor
    {
        Blue = 0,
        Black = 1,
        Brown = 2,
        Green = 3,
        Pink = 4,
        White = 5,
        Orange = 6
    }
    public class Player
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public HairColor HairColor { get; set; }
        //استحکام
        public int Strength { get; set; }
        //تعداد مسابقه
        public string Race { get; set; }
    }
}