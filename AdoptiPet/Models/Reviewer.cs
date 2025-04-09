﻿using System.Text.Json.Serialization;

namespace AdoptiPet.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public ICollection<Review> Reviews { get; set; }
    }
}
