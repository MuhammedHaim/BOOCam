using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AuthBOOCam.Models
{
    public class ShelfBooks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }

        public string ISBN { get; set; }

        public string Image_URL { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Publisher { get; set; }

        public string Original_Publisher_Year { get; set; }

        public string Average_Ratings { get; set; }

        public string Author_Average_Ratings { get; set; }

        public string UserId { get; set; }


    }
}