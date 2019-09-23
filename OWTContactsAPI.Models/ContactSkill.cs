using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OWTContactsAPI.Models
{
	public class ContactSkill
	{
		[Required]
		public int ContactId { get; set; }
		public Contact Contact { get; set; }
		[Required]
		public int SkillId { get; set; }
		public Skill Skill { get; set; }
		[Required]
		[ConcurrencyCheck]
		public int ExpertizeLevelId { get; set; }
		public ExpertizeLevel ExpertizeLevel { get; set; }
	}
}
