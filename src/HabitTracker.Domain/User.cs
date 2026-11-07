namespace HabitTracker.Domain;

public class User
{
    public int Id { get; init; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string NickName { get; private set; }
    private readonly List<Goal> _goals = new();

    public IReadOnlyCollection<Goal> Goals => _goals.AsReadOnly();

    public User(string email, string passwordHash, string nickName)
    {
        Email = NormalizeEmail(email);
        PasswordHash = CheckPasswordHash(passwordHash);
        NickName = CheckNickName(nickName);

    }

    public void ChangeEmail(string newEmail)
    {
        Email = NormalizeEmail(newEmail);
    }

    public void ChangeNickName(string nickName)
    {
        NickName = CheckNickName(nickName);
    }

    public void AddGoal(Goal goal)
    {
        ArgumentNullException.ThrowIfNull(goal);
        if (_goals.Contains(goal))
        {
            throw new ArgumentException("This goal is already added");
        }
        goal.AssignUser(this);
        _goals.Add(goal);
    }

    public void RemoveGoal(Goal goal)
    {
        ArgumentNullException.ThrowIfNull(goal);

        if (!_goals.Remove(goal))
            throw new ArgumentException("Goal was not found.");
    }

    private string NormalizeEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be null or whitespace.", nameof(email));
        }
        email = email.Trim().ToLowerInvariant();

        if (!System.Net.Mail.MailAddress.TryCreate(email, out _))
            throw new ArgumentException("Invalid email format.");

        return email;
    }

    private string CheckNickName(string nickName)
    {
        if (string.IsNullOrWhiteSpace(nickName))
            throw new ArgumentException("Nickname cannot be empty.");

        return nickName.Trim();
    }
    private string CheckPasswordHash(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
        {
            throw new ArgumentException("Password cannot be null or whitespace.");
        }
        return passwordHash;
    }
}
