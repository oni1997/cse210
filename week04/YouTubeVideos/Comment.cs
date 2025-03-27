using System;

namespace YouTubeVideos
{
    //this comment class responsible is for tracking commenter name and comment text
    public class Comment
    {
        //properties for the comment
        public string CommenterName { get; set; }
        public string CommentText { get; set; }

        //constructor to initialize a comment
        public Comment(string commenterName, string commentText)
        {
            CommenterName = commenterName;
            CommentText = commentText;
        }
    }
}