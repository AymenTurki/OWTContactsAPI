using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OWTContactsAPI.Models
{
	public class Contact
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ContactId { get; set; }
		[Required]
		[ConcurrencyCheck]
		[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "No digits or special characters are allowed.")]
		public string FirstName { get; set; }
		[Required]
		[ConcurrencyCheck]
		[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "No digits or special characters are allowed.")]
		public string LastName { get; set; }
		[Required]
		[ConcurrencyCheck]
		public string Address { get; set; }
		[Required]
		[ConcurrencyCheck]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[ConcurrencyCheck]
		[RegularExpression(@"^(\+41|0041|0){1}[2-9][1-9]{5}$", ErrorMessage = "It must be a personal swiss phone number.")]
		public string MobilePhoneNumber { get; set; }
		public ICollection<ContactSkill> ContactSkills { get; set; }
	}


}
