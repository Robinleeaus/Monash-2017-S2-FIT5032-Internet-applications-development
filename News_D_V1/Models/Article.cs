//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace News_D_V1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Article
    {
        public int articleId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        public string title { get; set; }
        [Required(ErrorMessage = "Content is required")]
        [Display(Name = "Content")]
        public string content { get; set; }
        public string contentInitial
        {
            get { return content != null ? Truncate(content, 200) : ""; }
        }
        [Required(ErrorMessage = "Date is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date")]
        public Nullable<System.DateTime> date { get; set; }
        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public string category { get; set; }
        [Display(Name = "Journalist")]
        public Nullable<int> journalistId { get; set; }
    
        public virtual Journalist Journalist { get; set; }

        public string Truncate(string text, int length)
        {
            if (text.Length > length)
            {
                return text.Substring(0, length) + " .......";
            }
            else
            {
                return text;
            }

        }
    }


}
