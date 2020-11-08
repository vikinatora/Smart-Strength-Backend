using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Strength_Backend.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public string Tempo { get; set; }

    }
}
