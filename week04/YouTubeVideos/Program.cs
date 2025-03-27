using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a list to store videos
            List<Video> videos = new List<Video>();

            //create videos and add comments
            Video video1 = new Video("Golang vs C# vs Java: Which is Best for APIs?", "freeCodeCamp", 2400);
            video1.AddComment(new Comment("APIBuilder", "Perfect comparison for my next project!"));
            video1.AddComment(new Comment("PerformancePro", "Golang's concurrency wins for me."));
            video1.AddComment(new Comment("EnterpriseDev", "C# still dominates Windows integration."));
            videos.Add(video1);

            Video video2 = new Video("I Built a Microservice in Golang vs Java vs C#", "TechWithTim", 3000);
            video2.AddComment(new Comment("MicroservicesFan", "Golang's goroutines made the difference!"));
            video2.AddComment(new Comment("JavaVeteran", "Spring Boot still has its place."));
            video2.AddComment(new Comment("CSharpEnthusiast", "ASP.NET Core handled scaling better."));
            videos.Add(video2);

            Video video3 = new Video("Why Golang Replaced Java at Our Company", "Google Developers", 1800);
            video3.AddComment(new Comment("CloudEngineer", "Memory efficiency was key for us."));
            video3.AddComment(new Comment("JavaLoyalist", "Still prefer Spring for complex systems."));
            video3.AddComment(new Comment("GoNewbie", "Learning curve wasn't as bad as expected."));
            videos.Add(video3);

            Video video4 = new Video("C# vs Golang: Which Should You Learn First?", "Programming with Mosh", 2700);
            video4.AddComment(new Comment("CareerChanger", "Golang's simplicity won me over."));
            video4.AddComment(new Comment("EnterpriseDev", "C# has better tooling for large teams."));
            video4.AddComment(new Comment("LanguageLearner", "Both are worth learning!"));
            videos.Add(video4);


            //i iterate through videos and display their details
            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                Console.WriteLine("Comments:");
                video.DisplayComments();
                Console.WriteLine();
            }
        }
    }
}