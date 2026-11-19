using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C# Classes", "Code Academy", 600);
        video1.AddComment(new Comment("Amina", "The examples made classes easier to understand."));
        video1.AddComment(new Comment("David", "I learned a lot from this video."));
        video1.AddComment(new Comment("Grace", "Please make a video about inheritance too."));
        videos.Add(video1);

        Video video2 = new Video("How to Bake Bread", "Home Kitchen", 900);
        video2.AddComment(new Comment("John", "My bread turned out great!"));
        video2.AddComment(new Comment("Sarah", "The kneading tip was very helpful."));
        video2.AddComment(new Comment("Peter", "Can I use whole wheat flour?"));
        videos.Add(video2);

        Video video3 = new Video("Walking in Kampala", "Explore Uganda", 480);
        video3.AddComment(new Comment("Mariam", "I recognized that street!"));
        video3.AddComment(new Comment("Brian", "Beautiful footage of the city."));
        video3.AddComment(new Comment("Esther", "I would love to see more places."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}