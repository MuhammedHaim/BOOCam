using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AuthBOOCam.Models
{
    public class SearchHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SearchID { get; set; }

        public string BookTitle { get; set; }


        public string BookImage { get; set; }


        public string Time { get; set; }

        
        public string UserID { get; set; }



    }
}