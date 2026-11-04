using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
        PasswordHash = passwordHash;
        NickName = nickName;

        if (string.IsNullOrWhiteSpace(PasswordHash))
            throw new ArgumentException("Password hash cannot be empty.");

        if (string.IsNullOrWhiteSpace(NickName))
            throw new ArgumentException("Nickname cannot be empty.");
    }

    public void ChangeEmail(string newEmail)
    {
        Email = NormalizeEmail(newEmail);
    }

    public void ChangeNickName(string nickName)
    {
        if (string.IsNullOrWhiteSpace(nickName))
            throw new ArgumentException("Nickname cannot be empty.");

        NickName = nickName.Trim();
    }

    public void AddGoal(Goal goal)
    {
        ArgumentNullException.ThrowIfNull(goal);

        _goals.Add(goal);
    }

    public void RemoveGoal(Goal goal)
    {
        _goals.Remove(goal);
    }

    public static string NormalizeEmail(string email)
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
}
