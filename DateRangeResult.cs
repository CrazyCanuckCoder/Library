﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    /// <summary>
    /// Contains a starting date and an ending date.
    /// </summary>
    /// 
    public class DateRangeResult
    {
        /// <summary>
        /// Gets/sets the starting date of the date range.
        /// </summary>
        /// 
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets/sets the ending date of the date range.
        /// </summary>
        /// 
        public DateTime End { get; set; }




        public DateRangeResult(DateTime NewStart, DateTime NewEnd)
        {
            this.Start = NewStart;
            this.End   = NewEnd;
        }
    }
}
