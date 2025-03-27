using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    //video class responsible for tracking video details and comments
    public class Video
    {
        //properties for the video
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }

        //list to store comments
        private List<Comment> Comments { get; set; }

        //constructor to initialize a video
        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        //method to add a comment to the video
        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        //method to return the number of comments
        public int GetNumberOfComments()
        {
            return Comments.Count;
        }

        //method to display all comments
        public void DisplayComments()
        {
            foreach (Comment comment in Comments)
            {
                Console.WriteLine($"  {comment.CommenterName}: {comment.CommentText}");
            }
        }
    }
}