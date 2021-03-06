﻿using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeaMonsterBlog.UI.Models
{
    public class DetailVM : LayoutVM, IValidatableObject
    {
        public Post Post { get; set; }
        public Comment NewComment { get; set; }
        public Reply NewReply { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if(NewReply == null)
            {
                if(string.IsNullOrWhiteSpace(NewComment.CommenterName) && string.IsNullOrWhiteSpace(NewComment.CommentText))
                    errors.Add(new ValidationResult("Please enter a name and a comment"));

                if (!string.IsNullOrWhiteSpace(NewComment.CommenterName) && string.IsNullOrWhiteSpace(NewComment.CommentText))
                    errors.Add(new ValidationResult("Please enter a comment"));

                if (!string.IsNullOrWhiteSpace(NewComment.CommenterName) && string.IsNullOrWhiteSpace(NewComment.CommentText))
                    errors.Add(new ValidationResult("Please enter a comment", new[] { "NewComment.CommentText" }));

                if (string.IsNullOrWhiteSpace(NewComment.CommenterName) && !string.IsNullOrWhiteSpace(NewComment.CommentText))
                    errors.Add(new ValidationResult("Please enter a name for your comment", new[] { "NewComment.CommenterName" }));
            }

            else if(NewReply != null)
            {
                if ((!string.IsNullOrWhiteSpace(NewComment.CommenterName) && !string.IsNullOrWhiteSpace(NewComment.CommentText)
                && !string.IsNullOrWhiteSpace(NewReply.ReplyName) && !string.IsNullOrWhiteSpace(NewReply.ReplyText))
                    || (!string.IsNullOrWhiteSpace(NewComment.CommenterName) && !string.IsNullOrWhiteSpace(NewComment.CommentText)
                && !string.IsNullOrWhiteSpace(NewReply.ReplyName) && string.IsNullOrWhiteSpace(NewReply.ReplyText))
                    || (!string.IsNullOrWhiteSpace(NewComment.CommenterName) && !string.IsNullOrWhiteSpace(NewComment.CommentText)
                && string.IsNullOrWhiteSpace(NewReply.ReplyName) && !string.IsNullOrWhiteSpace(NewReply.ReplyText))
                    || (string.IsNullOrWhiteSpace(NewComment.CommenterName) && !string.IsNullOrWhiteSpace(NewComment.CommentText)
                && !string.IsNullOrWhiteSpace(NewReply.ReplyName) && !string.IsNullOrWhiteSpace(NewReply.ReplyText))
                    || (!string.IsNullOrWhiteSpace(NewComment.CommenterName) && string.IsNullOrWhiteSpace(NewComment.CommentText)
                && !string.IsNullOrWhiteSpace(NewReply.ReplyName) && !string.IsNullOrWhiteSpace(NewReply.ReplyText))
                    || (string.IsNullOrWhiteSpace(NewComment.CommenterName) && !string.IsNullOrWhiteSpace(NewComment.CommentText)
                && !string.IsNullOrWhiteSpace(NewReply.ReplyName) && string.IsNullOrWhiteSpace(NewReply.ReplyText))
                    || (!string.IsNullOrWhiteSpace(NewComment.CommenterName) && string.IsNullOrWhiteSpace(NewComment.CommentText)
                && string.IsNullOrWhiteSpace(NewReply.ReplyName) && !string.IsNullOrWhiteSpace(NewReply.ReplyText))
                    || (string.IsNullOrWhiteSpace(NewComment.CommenterName) && !string.IsNullOrWhiteSpace(NewComment.CommentText)
                && string.IsNullOrWhiteSpace(NewReply.ReplyName) && !string.IsNullOrWhiteSpace(NewReply.ReplyText))
                    || (!string.IsNullOrWhiteSpace(NewComment.CommenterName) && string.IsNullOrWhiteSpace(NewComment.CommentText)
                && !string.IsNullOrWhiteSpace(NewReply.ReplyName) && string.IsNullOrWhiteSpace(NewReply.ReplyText)))
                {
                    errors.Add(new ValidationResult("Please choose a comment or a reply, but not both"));
                }

                if (string.IsNullOrWhiteSpace(NewComment.CommenterName) && string.IsNullOrWhiteSpace(NewComment.CommentText)
                    && string.IsNullOrWhiteSpace(NewReply.ReplyName) && string.IsNullOrWhiteSpace(NewReply.ReplyText))
                {
                    errors.Add(new ValidationResult("Please enter a comment or a reply"));
                }

                if (!string.IsNullOrWhiteSpace(NewComment.CommenterName) && string.IsNullOrWhiteSpace(NewComment.CommentText)
                    && string.IsNullOrWhiteSpace(NewReply.ReplyName) && string.IsNullOrWhiteSpace(NewReply.ReplyText))
                {
                    errors.Add(new ValidationResult("Please enter a comment to submit",
                        new[] { "NewComment.CommentText" }));
                }

                if (string.IsNullOrWhiteSpace(NewComment.CommenterName) && !string.IsNullOrWhiteSpace(NewComment.CommentText)
                    && string.IsNullOrWhiteSpace(NewReply.ReplyName) && string.IsNullOrWhiteSpace(NewReply.ReplyText))
                {
                    errors.Add(new ValidationResult("Please enter a name with your commment",
                        new[] { "NewComment.CommenterName" }));
                }


                if (string.IsNullOrWhiteSpace(NewComment.CommenterName) && string.IsNullOrWhiteSpace(NewComment.CommentText)
                    && string.IsNullOrWhiteSpace(NewReply.ReplyName) && !string.IsNullOrWhiteSpace(NewReply.ReplyText))
                {
                    errors.Add(new ValidationResult("Please enter a name to go with your reply",
                        new[] { "NewReply.ReplyName" }));
                }

                if (string.IsNullOrWhiteSpace(NewComment.CommenterName) && string.IsNullOrWhiteSpace(NewComment.CommentText)
                    && !string.IsNullOrWhiteSpace(NewReply.ReplyName) && string.IsNullOrWhiteSpace(NewReply.ReplyText))
                {
                    errors.Add(new ValidationResult("Please enter a reply",
                        new[] { "NewReply.ReplyText" }));
                }

            }

            return errors;
        }
    }
}