﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CEMS.Dal.Models;

[Table("speaker")]
public partial class Speaker
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("talk_id")]
    public Guid TalkId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("TalkId")]
    [InverseProperty("Speakers")]
    public virtual Talk Talk { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Speakers")]
    public virtual User User { get; set; }
}