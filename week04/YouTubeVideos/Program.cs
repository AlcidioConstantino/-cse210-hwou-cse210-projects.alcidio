using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Introduction to C#", "Code Academy", 600);
        video1.AddComment(new Comment("John", "This video helped me understand C# better."));
        video1.AddComment(new Comment("Maria", "Very clear explanation!"));
        video1.AddComment(new Comment("David", "I learned a lot from this video."));
        videos.Add(video1);

        Video video2 = new Video("Object-Oriented Programming", "Programming World", 720);
        video2.AddComment(new Comment("James", "The explanation about classes was great."));
        video2.AddComment(new Comment("Sarah", "I finally understand abstraction."));
        video2.AddComment(new Comment("Daniel", "Very useful lesson."));
        videos.Add(video2);

        Video video3 = new Video("Learn C# Classes", "Learn Programming", 540);
        video3.AddComment(new Comment("Peter", "Great tutorial!"));
        video3.AddComment(new Comment("Anna", "This was easy to follow."));
        video3.AddComment(new Comment("Michael", "I will practice this today."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
