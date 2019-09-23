using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OWTContactsAPI.Models
{
	public class ExpertizeLevel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ExpertizeLevelId { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public int NumericValue { get; set; }
	}
}
