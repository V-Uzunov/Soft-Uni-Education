using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private Dictionary<int, Car> participants;

    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new Dictionary<int, Car>();
        this.Winners=new List<Car>();
    }
    public Dictionary<int, Car> Participants { get; set; }
    public List<Car> Winners { get; set; }

    public abstract int GetPerformance(int id);

    public Dictionary<int, Car> GetWinners()
    {
        var winners = this.Participants.OrderByDescending(n => this.GetPerformance(n.Key)).Take(3).ToDictionary(n => n.Key, m => m.Value);

        return winners;
    }

    public int Length
    {
        get { return this.length; }
        set { this.length = value; }
    }

    public string Route
    {
        get { return this.route; }
        set { this.route = value; }
    }

    public int PrizePool
    {
        get { return this.prizePool; }
        set { this.prizePool = value; }
    }

    public List<int> GetPrizes()
    {
        var result = new List<int>();
        result.Add((this.PrizePool * 50) / 100);
        result.Add((this.PrizePool * 30) / 100);
        result.Add((this.PrizePool * 20) / 100);
        return result;
    }

    public string StartRace()
    {

        var winners = GetWinners();
        var prizes = GetPrizes();
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");

        for (int i = 0; i < winners.Count; i++)
        {
            var car = winners.ElementAt(i);

            sb.AppendLine($"{i + 1}. {car.Value.Brand} {car.Value.Model} {this.GetPerformance(car.Key)}PP - ${prizes[i]}");
        }
        
        return sb.ToString().Trim();
    }
}
