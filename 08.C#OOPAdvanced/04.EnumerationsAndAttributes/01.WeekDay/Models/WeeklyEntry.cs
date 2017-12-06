using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private WeekDay weekday;

    public WeeklyEntry(string weekday, string notes)
    {
        Enum.TryParse(weekday, out this.weekday);
        this.Notes = notes;
    }
    

    public WeekDay WeekDay => this.weekday;

    public string Notes { get; private set; }

    public override string ToString() => $"{this.WeekDay} {this.Notes}";

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;

        var weekDayComparison = this.weekday.CompareTo(other.weekday);

        if (weekDayComparison != 0)
        {
            return weekDayComparison;
        }

        return string.Compare(this.Notes, other.Notes, StringComparison.Ordinal);
    }
}