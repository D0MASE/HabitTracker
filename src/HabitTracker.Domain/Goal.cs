namespace HabitTracker.Domain;

public class Goal
{
    public int Id { get; init; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    private readonly List<Habit> _habits = new();

    public int UserId { get; private set; }
    public User User { get; private set; } = null!;

    public IReadOnlyCollection<Habit> Habits => _habits.AsReadOnly();

    public Goal(string name, string? description)
    {
        Name = CheckName(name);
        Description = CheckDescription(description);
    }

    public void ChangeName(string name)
    {
        Name = CheckName(name);
    }

    public void AddHabit(Habit habit)
    {
        ArgumentNullException.ThrowIfNull(habit);
        if (_habits.Contains(habit))
        {
            throw new ArgumentException("This habit is already added");
        }
        habit.AssignGoal(this);
        _habits.Add(habit);
    }

    public void RemoveHabit(Habit habit)
    {
        ArgumentNullException.ThrowIfNull(habit);
        _habits.Remove(habit);
    }

    public void ChangeDescription(string? description)
    {
        Description = CheckDescription(description);
    }


    private string CheckName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");
        return name.Trim();
    }

    private string? CheckDescription(string? description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            return null;
        }
        return description.Trim();
    }

    internal void AssignUser(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        if (User is not null)
        {
            throw new InvalidOperationException("User is already assigned to the goal");
        }
        User = user;
    }
}
