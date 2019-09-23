using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OWTContactsAPI.Models
{
	public class Skill
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SkillId { get; set; }
		[Required]
		[ConcurrencyCheck]
		public string Name { get; set; }
		public ICollection<ContactSkill> ContactSkills { get; set; }
	}
}
