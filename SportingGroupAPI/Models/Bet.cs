using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportingGroupAPI.Models
{
    public class Bet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int FixtureId { get; set; }
        public Fixture Fixture { get; set; }
        public string MatchWinner { get; set; }
        public Nullable<bool> IsWinner { get; set; }
    }
}
