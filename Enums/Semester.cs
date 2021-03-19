using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AP8PO_Final.Enums
{
    public enum Semester
    {
        /// <summary>
        /// Winter semester
        /// </summary>
        [Display(Name = "Zimní")]
        Winter,        
        /// /// <summary>
        /// Summer semester
        /// </summary>
        [Description("Letní")]
        Summer
    }
}
