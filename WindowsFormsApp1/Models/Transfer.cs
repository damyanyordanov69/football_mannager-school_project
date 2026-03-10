using System;

namespace FootballProject
{
    public class Transfer
    {
        public int TransferId { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } // За таблицата

        public int? FromTeamId { get; set; }
        public string FromTeamName { get; set; } // За таблицата

        public int ToTeamId { get; set; }
        public string ToTeamName { get; set; } // За таблицата

        public decimal TransferFee { get; set; }
        public DateTime TransferDate { get; set; }
    }
}