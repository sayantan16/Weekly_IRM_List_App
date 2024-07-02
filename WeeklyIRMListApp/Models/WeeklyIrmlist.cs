using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeeklyIRMListApp.Models;

public partial class WeeklyIrmlist
{
    [Key]
    public string Key { get; set; } = null!;

    public string ChangeTicket { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public string IssueType { get; set; } = null!;

    public string Applications { get; set; } = null!;

    public string Reporter { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime TargetEndDateTime { get; set; }

    public string ReviewStatus { get; set; } = null!;

    public string PrerequisiteTicket { get; set; } = null!;

    public string MiddlewareTask { get; set; } = null!;

    public string BuildType { get; set; } = null!;

    public string ElevatedPermission { get; set; } = null!;

    public string TakeoffsOwner { get; set; } = null!;

    public string Remarks { get; set; } = null!;

    [NotMapped]
    public string Flag { get; set; } = null!;
}
