using DataStoreDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDataStore.Models
{
    public class DocumentViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Автор")]
        public User Author { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime Date { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string FilePath { get; set; }
    }
}