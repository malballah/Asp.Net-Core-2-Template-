using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComName.ProjName.Domain
{
    public abstract class DbEntity<TPrimaryKey>
    {
        [Key]
        public TPrimaryKey Id { get; set; }
    }
}
