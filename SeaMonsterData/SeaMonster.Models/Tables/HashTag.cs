using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaMonster.Models.Tables
{
    public class HashTag
    {
        public int HashtagID { get; set; }
        public string Hashtag { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
