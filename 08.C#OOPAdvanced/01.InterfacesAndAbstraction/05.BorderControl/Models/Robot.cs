namespace _05.BorderControl
{
    public class Robot : IBoearder
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; private set; }
        public string Id { get; private set; }
        
    }
}
