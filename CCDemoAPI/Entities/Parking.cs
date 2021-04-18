namespace CCDemoAPI.Entities
{
    public class Parking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Location Location { get; set; }
    }
}