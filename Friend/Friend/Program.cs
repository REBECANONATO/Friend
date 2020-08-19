using System;
using System.Collections.Generic;
using System.Linq;

public class Friend
{
    public string Email { get; private set; }
    public ICollection<Friend> Friends { get; private set; }


    public Friend(string email)
    {
        this.Email = email;
        this.Friends = new List<Friend>();
    }


    public void AddFriendship(Friend friend)
    {
        this.Friends.Add(friend);
        friend.Friends.Add(this);
    }


    public bool CanBeConnected(Friend friend)
    {
        return this.Friends.Any(f => f.Friends.Any(f1 => f1.Email == friend.Email));
    }


    public static void Main(string[] args)
    {
        Friend a = new Friend("A");
        Friend b = new Friend("B");
        Friend c = new Friend("C");

        a.AddFriendship(b);
        b.AddFriendship(c);

        Console.WriteLine(a.CanBeConnected(c));
    }
}