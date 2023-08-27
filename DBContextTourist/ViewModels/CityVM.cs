namespace DBContextTourist.ViewModels
{
    public class CityVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public int GovernerateId { get; set; }
    }

}
