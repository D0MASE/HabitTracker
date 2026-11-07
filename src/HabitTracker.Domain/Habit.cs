namespace HabitTracker.Domain;

public class Habit
{
    public int Id { get; init; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal DailyReward { get; private set; }
    public decimal? WeeklyReward { get; private set; }

    public Goal Goal { get; private set; } = null!;
    public int GoalId { get; private set; }

    private readonly List<HabitCompletion> _habitCompletions = new();

    public IReadOnlyCollection<HabitCompletion> HabitCompletions => _habitCompletions.AsReadOnly();

    public Habit(string name, string? description, decimal dailyReward, decimal? weeklyReward)
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

    private decimal CheckDailyReward(decimal dailyReward)
    {

        if (decimal.IsNegative(dailyReward))
            throw new ArgumentException("Daily Reward can't be negative");
        return dailyReward;
    }

    public void ChangeDailyReward(decimal dailyReward)
    {
        DailyReward = CheckDailyReward(dailyReward);
    }

    private decimal? CheckWeeklyReward(decimal? weeklyReward)
    {
        if (weeklyReward.HasValue)
        {
            if (decimal.IsNegative(weeklyReward.Value))
                throw new ArgumentException("Weekly Reward can't be negative");
            return weeklyReward;
        }
        return null;
    }

    public void ChangeWeeklyReward(decimal? weeklyReward)
    {
        WeeklyReward = CheckWeeklyReward(weeklyReward);
    }

    public void AddCompletion(DateOnly date)
    {
        if (_habitCompletions.Any(competion => competion.Date.Equals(date)))
            throw new ArgumentException("This Habit was already completed on the selected day");
        _habitCompletions.Add(new HabitCompletion(date, this));
    }

    internal void AssignGoal(Goal goal)
    {
        ArgumentNullException.ThrowIfNull(goal);
        if (Goal is not null)
        {
            throw new InvalidOperationException("Habit is already assigned to the goal");
        }
        Goal = goal;
    }
}
