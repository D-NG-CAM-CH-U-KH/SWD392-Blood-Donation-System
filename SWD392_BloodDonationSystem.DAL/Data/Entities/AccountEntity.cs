﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SWD392_BloodDonationSystem.DAL.Data.Entities;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

[Table("account")]
public class AccountEntity
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    [Column("email", TypeName = "varchar(100)")]
    public string Email { get; set; }
    
    [Required]
    [Column("password")]
    public string Password { get; set; }
    
    [ForeignKey(nameof(RoleEntity))]
    [Column("role_id")]
    public int RoleId { get; set; }
    
    public required RoleEntity RoleEntity { get; set; }
    
    [Required]
    [Column("first_name", TypeName = "varchar(100)")]
    public string FirstName { get; set; }
    
    [Required]
    [Column("last_name", TypeName = "varchar(100)")]
    public string LastName { get; set; }
    
    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}