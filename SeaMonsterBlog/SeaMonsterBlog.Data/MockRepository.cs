using SeaMonsterBlog.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonsterBlog.Data
{
    public class MockRepository : IRepository
    {
        static IEnumerable<Category> categories;
        static IEnumerable<Post> posts;
        static IEnumerable<Comment> comments;
        static IEnumerable<Reply> replies;
        static IEnumerable<Image> images;

        static int postIdCount = 11;
        static int imageIdCount = 4;

       public MockRepository()
        {
            categories = new List<Category>()
            {
                new Category {CategoryID = 1, CategoryTag = "Sitings", DateAdded = new DateTime (2017, 10, 31)},
                new Category {CategoryID = 2, CategoryTag = "Treasure", DateAdded = new DateTime (2017, 10, 31)},
                new Category { CategoryID = 3, CategoryTag = "Submarines", DateAdded = new DateTime (2017, 10, 31)}
            };

            posts = new List<Post>()
            {
                new Post {PostId = 1, UserId = 1, DateCreated = new DateTime(2017, 10, 31), ToPostDate = new DateTime(2017, 10, 31), ExpDate = new DateTime(2017, 12, 31), IsPublished = true, IsStatic = false, PostTitle = "AGING SEA MONSTERS", PostText = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n</head>\r\n<body>\r\n<p>Weigh anchor keel code of conduct gaff cog parley quarter clap of thunder smartly hands. Red ensign Privateer hail-shot hempen halter crimp Plate Fleet tender furl stern clipper.<em> Jack Ketch heave to lugger take a caulk Shiver me timbers nipperkin avast scuttle rigging barkadeer.</em></p>\r\n<p><span style=\"background-color: #003366;\">Careen provost fire ship poop deck jack pillage transom six pounders code of conduct rum.</span> Bring a spring upon her cable mizzenmast chase sutler grapple piracy Plate Fleet poop deck bilged on her anchor avast. Pirate Round Spanish Main prow run a rig aft swab pressgang Jack Ketch hempen halter spike.</p>\r\n<p><img src=\"http://cdn.playbuzz.com/cdn/04bce4ec-d2b0-4b81-9b2a-f47bb931fffb/1ffe3b01-5a1e-4d25-8dc8-c598d4bfdace_560_420.jpg\" alt=\"big teeth\" width=\"300\" height=\"225\" /></p>\r\n<ul>\r\n<li>Driver scurvy knave belaying pin wherry grog blossom flogging cog bilge gun.</li>\r\n<li>List chase guns Davy Jones' Locker Brethren of the Coast</li>\r\n<li>Privateer haul wind belay bring a spring upon her cable long boat spirits.</li>\r\n<li>Knave warp bilge water Barbary Coast gunwalls</li>\r\n<li>Admiral of the Black brigantine Brethren of the Coast schooner gibbet.</li>\r\n</ul>\r\n</body>\r\n</html>"},
                new Post {PostId = 2, UserId = 1, DateCreated = new DateTime(2017, 10, 31), ToPostDate = new DateTime(2017, 10, 31), ExpDate = new DateTime(2017, 12, 31), IsPublished = true, IsStatic = false, PostTitle = "Anchors Ahoy", PostText = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n</head>\r\n<body>\r\n<p>Hail-shot handsomely list barque broadside jolly boat bowsprit cable no prey, no pay swab. Maroon parley piracy list wench case shot hulk keelhaul yardarm man-of-war. Grapple ballast warp scuppers landlubber or just lubber Nelsons folly deadl<img style=\"background-color: #ffffff; color: #626262; display: block; margin-left: auto; margin-right: auto;\" src=\"https://upload.wikimedia.org/wikipedia/commons/thumb/9/9d/Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg/220px-Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg\" alt=\"kraken\" width=\"114\" height=\"175\" />ights chantey Barbary Coast six pounders.</p>\r\n<p>Gabion avast ahoy brig marooned&nbsp;Kraken Sink me Pieces of Eight belay boatswain salmagundi. Salmagundi poop deck list swing the lead topgallant Privateer American Main black spot crimp keelhaul. Barkadeer rum spike gun parley Jack Tar hardtack gaff galleon doubloon.</p>\r\n</body>\r\n</html>"},
                new Post {PostId = 3, UserId = 1, DateCreated = new DateTime(2017, 10, 31), ToPostDate = new DateTime(2017, 10, 31), ExpDate = new DateTime(2017, 12, 31), IsPublished = true, IsStatic = false, PostTitle = "Kraken - 2nd encounter", PostText = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n</head>\r\n<body>\r\n<p>Hail-shot handsomely list barque broadside jolly boat bowsprit cable no prey, no pay swab. Maroon parley piracy list wench case shot hulk keelhaul yardarm man-of-war. Grapple ballast warp scuppers landlubber or just lubber Nelsons folly deadl<img style=\"background-color: #ffffff; color: #626262; display: block; margin-left: auto; margin-right: auto;\" src=\"https://upload.wikimedia.org/wikipedia/commons/thumb/9/9d/Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg/220px-Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg\" alt=\"kraken\" width=\"114\" height=\"175\" />ights chantey Barbary Coast six pounders.</p>\r\n<p>Gabion avast ahoy brig marooned&nbsp;Kraken Sink me Pieces of Eight belay boatswain salmagundi. Salmagundi poop deck list swing the lead topgallant Privateer American Main black spot crimp keelhaul. Barkadeer rum spike gun parley Jack Tar hardtack gaff galleon doubloon.</p>\r\n</body>\r\n</html>"},
                new Post {PostId = 4, UserId = 1, DateCreated = new DateTime(2017, 10, 31), ToPostDate = new DateTime(2017, 10, 31), ExpDate = new DateTime(2017, 12, 31), IsPublished = false, IsStatic = false, PostTitle = "Work in progress", PostText = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n</head>\r\n<body>\r\n<p>Hail-shot handsomely list barque broadside jolly boat bowsprit cable no prey, no pay swab. Maroon parley piracy list wench case shot hulk keelhaul yardarm man-of-war. Grapple ballast warp scuppers landlubber or just lubber Nelsons folly deadl<img style=\"background-color: #ffffff; color: #626262; display: block; margin-left: auto; margin-right: auto;\" src=\"https://upload.wikimedia.org/wikipedia/commons/thumb/9/9d/Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg/220px-Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg\" alt=\"kraken\" width=\"114\" height=\"175\" />ights chantey Barbary Coast six pounders.</p>\r\n<p>Gabion avast ahoy brig marooned&nbsp;Kraken Sink me Pieces of Eight belay boatswain salmagundi. Salmagundi poop deck list swing the lead topgallant Privateer American Main black spot crimp keelhaul. Barkadeer rum spike gun parley Jack Tar hardtack gaff galleon doubloon.</p>\r\n</body>\r\n</html>"},
                new Post {PostId = 5, UserId = 2, DateCreated = new DateTime(2017, 10, 31), ToPostDate = new DateTime(2017, 10, 31), ExpDate = new DateTime(2017, 12, 31), IsPublished = false, IsStatic = false, PostTitle = "Please Approve My Work", PostText = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n</head>\r\n<body>\r\n<p>Hail-shot handsomely list barque broadside jolly boat bowsprit cable no prey, no pay swab. Maroon parley piracy list wench case shot hulk keelhaul yardarm man-of-war. Grapple ballast warp scuppers landlubber or just lubber Nelsons folly deadl<img style=\"background-color: #ffffff; color: #626262; display: block; margin-left: auto; margin-right: auto;\" src=\"https://upload.wikimedia.org/wikipedia/commons/thumb/9/9d/Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg/220px-Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg\" alt=\"kraken\" width=\"114\" height=\"175\" />ights chantey Barbary Coast six pounders.</p>\r\n<p>Gabion avast ahoy brig marooned&nbsp;Kraken Sink me Pieces of Eight belay boatswain salmagundi. Salmagundi poop deck list swing the lead topgallant Privateer American Main black spot crimp keelhaul. Barkadeer rum spike gun parley Jack Tar hardtack gaff galleon doubloon.</p>\r\n</body>\r\n</html>"},
                new Post {PostId = 11, UserId = 1, DateCreated = new DateTime(2017, 10, 31), IsPublished = true, IsStatic = false, PostTitle = "Glimps of the Loch Ness", PostText = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n</head>\r\n<body>\r\n<p>Hail-shot handsomely list barque broadside jolly boat bowsprit cable no prey, no pay swab. Maroon parley piracy list wench case shot hulk keelhaul yardarm man-of-war. Grapple ballast warp scuppers landlubber or just lubber Nelsons folly deadl<img style=\"background-color: #ffffff; color: #626262; display: block; margin-left: auto; margin-right: auto;\" src=\"https://upload.wikimedia.org/wikipedia/commons/thumb/9/9d/Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg/220px-Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg\" alt=\"kraken\" width=\"114\" height=\"175\" />ights chantey Barbary Coast six pounders.</p>\r\n<p>Gabion avast ahoy brig marooned&nbsp;Kraken Sink me Pieces of Eight belay boatswain salmagundi. Salmagundi poop deck list swing the lead topgallant Privateer American Main black spot crimp keelhaul. Barkadeer rum spike gun parley Jack Tar hardtack gaff galleon doubloon.</p>\r\n</body>\r\n</html>"},
                new Post {PostId = 6, UserId = 1, DateCreated = new DateTime(2017, 10, 31), IsPublished = true, IsStatic = false, PostTitle = "Alvin", PostText = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n</head>\r\n<body>\r\n<p>Hail-shot handsomely list barque broadside jolly boat bowsprit cable no prey, no pay swab. Maroon parley piracy list wench case shot hulk keelhaul yardarm man-of-war. Grapple ballast warp scuppers landlubber or just lubber Nelsons folly deadl<img style=\"background-color: #ffffff; color: #626262; display: block; margin-left: auto; margin-right: auto;\" src=\"https://upload.wikimedia.org/wikipedia/commons/thumb/9/9d/Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg/220px-Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg\" alt=\"kraken\" width=\"114\" height=\"175\" />ights chantey Barbary Coast six pounders.</p>\r\n<p>Gabion avast ahoy brig marooned&nbsp;Kraken Sink me Pieces of Eight belay boatswain salmagundi. Salmagundi poop deck list swing the lead topgallant Privateer American Main black spot crimp keelhaul. Barkadeer rum spike gun parley Jack Tar hardtack gaff galleon doubloon.</p>\r\n</body>\r\n</html>"},
                new Post {PostId = 7, UserId = 1, DateCreated = new DateTime(2017, 10, 31),  IsPublished = true, IsStatic = false, PostTitle = "Doubloons vs Bitcoins", PostText = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n</head>\r\n<body>\r\n<p>Hail-shot handsomely list barque broadside jolly boat bowsprit cable no prey, no pay swab. Maroon parley piracy list wench case shot hulk keelhaul yardarm man-of-war. Grapple ballast warp scuppers landlubber or just lubber Nelsons folly deadl<img style=\"background-color: #ffffff; color: #626262; display: block; margin-left: auto; margin-right: auto;\" src=\"https://upload.wikimedia.org/wikipedia/commons/thumb/9/9d/Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg/220px-Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg\" alt=\"kraken\" width=\"114\" height=\"175\" />ights chantey Barbary Coast six pounders.</p>\r\n<p>Gabion avast ahoy brig marooned&nbsp;Kraken Sink me Pieces of Eight belay boatswain salmagundi. Salmagundi poop deck list swing the lead topgallant Privateer American Main black spot crimp keelhaul. Barkadeer rum spike gun parley Jack Tar hardtack gaff galleon doubloon.</p>\r\n</body>\r\n</html>"},
                new Post {PostId = 8, UserId = 1, DateCreated = new DateTime(2017, 10, 31), ToPostDate = new DateTime(2017, 10, 31), ExpDate = new DateTime(2017, 12, 31), IsPublished = true, IsStatic = false, PostTitle = "Anchors Ahoy", PostText = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n</head>\r\n<body>\r\n<p>Hail-shot handsomely list barque broadside jolly boat bowsprit cable no prey, no pay swab. Maroon parley piracy list wench case shot hulk keelhaul yardarm man-of-war. Grapple ballast warp scuppers landlubber or just lubber Nelsons folly deadl<img style=\"background-color: #ffffff; color: #626262; display: block; margin-left: auto; margin-right: auto;\" src=\"https://upload.wikimedia.org/wikipedia/commons/thumb/9/9d/Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg/220px-Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg\" alt=\"kraken\" width=\"114\" height=\"175\" />ights chantey Barbary Coast six pounders.</p>\r\n<p>Gabion avast ahoy brig marooned&nbsp;Kraken Sink me Pieces of Eight belay boatswain salmagundi. Salmagundi poop deck list swing the lead topgallant Privateer American Main black spot crimp keelhaul. Barkadeer rum spike gun parley Jack Tar hardtack gaff galleon doubloon.</p>\r\n</body>\r\n</html>"},
                new Post {PostId = 9, UserId = 1, DateCreated = new DateTime(2017, 10, 31), IsPublished = true, IsStatic = true, PostTitle = "About Me", PostText = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n</head>\r\n<body>\r\n<p>Hail-shot handsomely list barque broadside jolly boat bowsprit cable no prey, no pay swab. Maroon parley piracy list wench case shot hulk keelhaul yardarm man-of-war. Grapple ballast warp scuppers landlubber or just lubber Nelsons folly deadl<img style=\"background-color: #ffffff; color: #626262; display: block; margin-left: auto; margin-right: auto;\" src=\"https://upload.wikimedia.org/wikipedia/commons/thumb/9/9d/Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg/220px-Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg\" alt=\"kraken\" width=\"114\" height=\"175\" />ights chantey Barbary Coast six pounders.</p>\r\n<p>Gabion avast ahoy brig marooned&nbsp;Kraken Sink me Pieces of Eight belay boatswain salmagundi. Salmagundi poop deck list swing the lead topgallant Privateer American Main black spot crimp keelhaul. Barkadeer rum spike gun parley Jack Tar hardtack gaff galleon doubloon.</p>\r\n</body>\r\n</html>"},
                new Post {PostId = 10, UserId = 1, DateCreated = new DateTime(2017, 10, 31), IsPublished = true, IsStatic = true, PostTitle = "About The Crew", PostText = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n</head>\r\n<body>\r\n<p>Hail-shot handsomely list barque broadside jolly boat bowsprit cable no prey, no pay swab. Maroon parley piracy list wench case shot hulk keelhaul yardarm man-of-war. Grapple ballast warp scuppers landlubber or just lubber Nelsons folly deadl<img style=\"background-color: #ffffff; color: #626262; display: block; margin-left: auto; margin-right: auto;\" src=\"https://upload.wikimedia.org/wikipedia/commons/thumb/9/9d/Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg/220px-Colossal_octopus_by_Pierre_Denys_de_Montfort.jpg\" alt=\"kraken\" width=\"114\" height=\"175\" />ights chantey Barbary Coast six pounders.</p>\r\n<p>Gabion avast ahoy brig marooned&nbsp;Kraken Sink me Pieces of Eight belay boatswain salmagundi. Salmagundi poop deck list swing the lead topgallant Privateer American Main black spot crimp keelhaul. Barkadeer rum spike gun parley Jack Tar hardtack gaff galleon doubloon.</p>\r\n</body>\r\n</html>"},
            };

            comments = new List<Comment>()
            {
                new Comment {CommentId = 1, PostId = 1, CommenterName = "Bob", CommentDate = new DateTime(2017, 11, 2), CommentText = "Dude, that was far out", IsShown = true },
                new Comment {CommentId = 2, PostId = 1, CommenterName = "Joe", CommentDate = new DateTime(2017, 11, 2), CommentText = "For Realz", IsShown = true },
                new Comment {CommentId = 3, PostId = 1, CommenterName = "Anon", CommentDate = new DateTime(2017, 11, 2), CommentText = "Double rainbow!!", IsShown = true },
                new Comment {CommentId = 4, PostId = 2, CommenterName = "Bob", CommentDate = new DateTime(2017, 11, 2), CommentText = "Who lives in a pinapple under the sea", IsShown = true },
                new Comment {CommentId = 5, PostId = 2, CommenterName = "Ali", CommentDate = new DateTime(2017, 11, 2), CommentText = "Argggg...", IsShown = true },
                new Comment {CommentId = 6, PostId = 3, CommenterName = "Jane", CommentDate =new  DateTime(2017, 11, 2), CommentText = "I think your work is stupid", IsShown = false },
                new Comment {CommentId = 7, PostId = 3, CommenterName = "Bob", CommentDate = new DateTime(2017, 11, 2), CommentText = "I can breath under water", IsShown = true },
                new Comment {CommentId = 8, PostId = 3, CommenterName = "Zeb", CommentDate = new DateTime(2017, 11, 2), CommentText = "Slander slander slander", IsShown = false },
                new Comment {CommentId = 9, PostId = 6, CommenterName = "Bob", CommentDate = new DateTime(2017, 11, 2), CommentText = "somewhat critical comment", IsShown = true },
                new Comment {CommentId = 10, PostId = 6, CommenterName = "Tom", CommentDate = new DateTime(2017, 11, 2), CommentText = "You are totally awesome", IsShown = true },
                new Comment {CommentId = 11, PostId = 6, CommenterName = "Bob", CommentDate = new DateTime(2017, 11, 2), CommentText = "You guys do great work, keep it up!", IsShown = true },
                new Comment {CommentId = 12, PostId = 7, CommenterName = "Anon", CommentDate = new DateTime(2017, 11, 2), CommentText = "blah blah blah", IsShown = true },
                new Comment {CommentId = 13, PostId = 7, CommenterName = "Bub", CommentDate = new DateTime(2017, 11, 2), CommentText = "Running out of stuff to say", IsShown = true },
                new Comment {CommentId = 14, PostId = 7, CommenterName = "Bob", CommentDate = new DateTime(2017, 11, 2), CommentText = "wishing i was more clever", IsShown = false },
                new Comment {CommentId = 15, PostId = 7, CommenterName = "Bob", CommentDate = new DateTime(2017, 11, 2), CommentText = "Dropping the mic.", IsShown = true }
            };

            replies = new List<Reply>()
            {
                new Reply {ReplyID = 1, CommentID = 1, ReplyDate = new DateTime(2017, 11, 2), ReplyName = "Bob", ReplyText = "Replying to my own comment like a total nerd!", IsShown = true},
                new Reply {ReplyID = 2, CommentID = 1, ReplyDate = new DateTime(2017, 11, 3), ReplyName = "Jane", ReplyText = "Total nerd..."},
                new Reply {ReplyID = 3, CommentID = 2, ReplyDate = new DateTime(2017, 11, 3), ReplyName = "Jane", ReplyText = "Blah blah blah blah blah"},
                new Reply {ReplyID = 4, CommentID = 6, ReplyDate = new DateTime(2017, 11, 3), ReplyName = "Jane", ReplyText = "Blah blah blah blah blah"},
                new Reply {ReplyID = 5, CommentID = 6, ReplyDate = new DateTime(2017, 11, 3), ReplyName = "Jane", ReplyText = "Blah blah blah blah blah"},
                new Reply {ReplyID = 6, CommentID = 8, ReplyDate = new DateTime(2017, 11, 3), ReplyName = "Jane", ReplyText = "Blah blah blah blah blah"},
                new Reply {ReplyID = 7, CommentID = 10, ReplyDate = new DateTime(2017, 11, 3), ReplyName = "Jane", ReplyText = "Blah blah blah blah blah"},
                new Reply {ReplyID = 8, CommentID = 10, ReplyDate = new DateTime(2017, 11, 3), ReplyName = "Jane", ReplyText = "Blah blah blah blah blah"},
                new Reply {ReplyID = 9, CommentID = 14, ReplyDate = new DateTime(2017, 11, 3), ReplyName = "Jane", ReplyText = "Blah blah blah blah blah"},
            };

            images = new List<Image>()
            {
                new Image {ImageId = 1, ImageName = "narwhal.jpg"},
                new Image {ImageId = 2, ImageName = "kraken.jpg"},
                new Image {ImageId = 3, ImageName = "submarine.jpg"}
            };
        }

        public int CreateNewPost(Post post)
        {
            var list = posts.ToList();
            post.PostId = postIdCount;
            postIdCount++;
            list.Add(post);
            posts = list;
            return postIdCount - 1;
        }

        public void SavePost(Post post)
        {
            var list = (from p in posts
                       where p.PostId != post.PostId
                       select p).ToList();
            list.Add(post);
            posts = list;
        }

        public List<Category> GetAllCategories()
        {
            return categories.ToList();
        }

        public List<Post> GetAllPosts()
        {
            return posts.ToList();
        }

        
        public List<Image> GetAllImages()
        {
            return images.ToList();
        }

        public void SaveNewImage(string fileName)
        {
            var list = images.ToList();
            Image image = new Image { ImageId = imageIdCount, ImageName = fileName };
            list.Add(image);
            images = list;
            imageIdCount++;
        }

        public Post GetPostByID(int postID)
        {
            return posts.FirstOrDefault(p => p.PostId == postID);

        }

        public List<Comment> GetAllComments()
        {
            return comments.ToList();
        }

        public List<Reply> GetAllReply()
        {
            return replies.ToList();
        }
    }
}
