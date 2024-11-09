using System;
using PodcastAPI.Models;
namespace PodcastAPI.Data;

public class UserData
{
	public static List<User> Users = new()
	{
		new()
		{
			Id = 1,
			FirstName = "Alex",
			LastName = "Berka",
			Username = "alexberka",
			ImageUrl = "",
			DateJoined = new DateTime(2024, 10, 15),
			Uid = "gKwUrKOtRCgw7JjrbxJrbf612dt2"
        },
		new()
		{
			Id = 2,
			FirstName = "Max",
			LastName = "Jones",
			Username = "maxjones",
			ImageUrl = "",
			DateJoined = new DateTime(2024, 10, 15),
			Uid = "5cMGwFoo4VfmsK04V8TXIciut862"
        },
		new()
		{
			Id = 3,
			FirstName = "Josh",
			LastName = "Gochey",
			Username = "joshgochey",
			ImageUrl = "",
			DateJoined = new DateTime(2024, 10, 15),
			Uid = "kTXfa5EXDtUWx6PqVcRMJPBVcGZ2"
        },
		new()
		{
			Id = 4,
			FirstName = "Brit",
			LastName = "Gore",
			Username = "britgore",
			ImageUrl = "",
			DateJoined = new DateTime(2024, 10, 15),
			Uid = "qGLQ1gzuAmTsgtAXAh7TT3YlkEE2"
        },
	};
}

