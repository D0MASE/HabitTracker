namespace HabitTracker.Domain;

public class HabitCompletion
{
    public int Id { get; init; }
    public DateOnly Date { get; init; }

    public int HabitId { get; init; }
    public Habit Habit { get; private set; }

    public HabitCompletion(DateOnly date, Habit habit)
    {
        Date = CheckDate(date);
        Habit = CheckHabit(habit);
    }

    private DateOnly CheckDate(DateOnly date)
    {
        if (date > DateOnly.FromDateTime(DateTime.Today))
            throw new ArgumentException("Date can't be selected in the future");
        return date;
    }
    private Habit CheckHabit(Habit habit)
    {
        ArgumentNullException.ThrowIfNull(habit);
        return habit;
    }
}
