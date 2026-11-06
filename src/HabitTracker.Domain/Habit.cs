namespace HabitTracker.Domain;

public class Habit
{
    public int Id { get; init; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public double DailyReward { get; private set; }
    public double? WeeklyReward { get; private set; }

    private readonly List<HabitCompletion> _habitCompletions = new();

    public IReadOnlyCollection<HabitCompletion> HabitCompletions => _habitCompletions.AsReadOnly();

    public Habit(string name, string? description, double dailyReward, double? weeklyReward)
    {
        Name = CheckName(name);
        Description = CheckDescription(description);
        DailyReward = CheckDailyReward(dailyReward);
        WeeklyReward = CheckWeeklyReward(weeklyReward);

    }

    private string CheckName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");
        return name.Trim();
    }
    public void ChangeName(string name)
    {
        Name = CheckName(name);
    }

    private string? CheckDescription(string? description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            return null;
        }
        return description.Trim();
    }

    public void ChangeDescription(string? description)
    {
        Description = CheckDescription(description);
    }

    private double CheckDailyReward(double dailyReward)
    {
        if (double.IsFinite(dailyReward))
        {
            if (double.IsNegative(dailyReward))
                throw new ArgumentException("Daily Reward can't be negative");
            return dailyReward;
        }
        throw new ArgumentException("Daily Reward has to be finite");

    }

    public void ChangeDailyReward(double dailyReward)
    {
        DailyReward = CheckDailyReward(dailyReward);
    }

    private double? CheckWeeklyReward(double? weeklyReward)
    {
        if (weeklyReward.HasValue)
        {
            if (!double.IsFinite(weeklyReward.Value))
                throw new ArgumentException("Weekly Reward has to be finite");
            if (double.IsNegative(weeklyReward.Value))
                throw new ArgumentException("Weekly Reward can't be negative");
            return weeklyReward;
        }
        return null;
    }

    public void ChangeWeeklyReward(double? weeklyReward)
    {
        WeeklyReward = CheckWeeklyReward(weeklyReward);
    }

    public void AddCompletion (HabitCompletion habitCompletion)
    {
        ArgumentNullException.ThrowIfNull(habitCompletion);
        if(_habitCompletions.Any(competion => competion.Date.Equals(habitCompletion.Date)))
            throw new ArgumentException("This Habit was already completed on the selected day");
        _habitCompletions.Add(habitCompletion);
    }

}
