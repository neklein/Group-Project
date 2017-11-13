using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeaMonsterBlog.UI.Models
{
    public class CreateEditVM : LayoutVM, IValidatableObject
    {
        public Post Post { get; set; }
        public List<Image> Images { get; set; }
        public string ImageTitle { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<int> ChosenCategories { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if(string.IsNullOrWhiteSpace(Post.Author))
                errors.Add(new ValidationResult("Please enter an author name", new[] { "Post.Author" }));

            if(string.IsNullOrWhiteSpace(Post.PostTitle))
                errors.Add(new ValidationResult("Please enter a title", new[] { "Post.PostTitle" }));

            if(string.IsNullOrWhiteSpace(Post.PostText))
                errors.Add(new ValidationResult("Please enter some text for your blog post", new[] { "Post.PostText" }));

            return errors;
        }
    }
}