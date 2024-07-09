namespace WeeklyIRMListApp.Models.ModelDTO
{
    public class WeeklyIrmlistDto
    {
        public string Key { get; set; }
        public string ChangeTicket { get; set; }
        public string Summary { get; set; }
        public string IssueType { get; set; }
        public string Applications { get; set; }
        public string Reporter { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime TargetEndDateTime { get; set; }
        public string ReviewStatus { get; set; }
        public string PrerequisiteTicket { get; set; }
        public string MiddlewareTask { get; set; }
        public string BuildType { get; set; }
        public string ElevatedPermission { get; set; }
        public string TakeoffsOwner { get; set; }
        public string Remarks { get; set; }
        public string Flag { get; set; } // Include the Flag property
    }
}
