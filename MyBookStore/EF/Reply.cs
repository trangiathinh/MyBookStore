using System;
using System.Collections.Generic;

namespace EF
{
    public partial class Reply
    {
        public Guid Id { get; set; }
        public Guid IdRating { get; set; }
        public string ReplyText { get; set; }

        public virtual Rating IdRatingNavigation { get; set; }
    }
}
