namespace _06.BirthdayCelebrations
{
    public class Robot : IBeing
    {
        public Robot(string id, string model)
        {
            this.Model = model;
            this.Id = id;            
        }
        public string Id { get; private set; }
        public string Model { get; private set; }
    }
}
