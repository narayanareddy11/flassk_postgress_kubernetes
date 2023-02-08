using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using CsvHelper.Configuration.Attributes;

namespace TitanicAPI.Models
{
	[DataContract]
	public class Person
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public string Uuid { get; set; }

		[Name("Name")] public string Name { get; set; }

		[Name("Pclass")] public int PassengerClass { get; set; }


		[Name("Survived")]
		[DataMember(Name = "Survived", EmitDefaultValue = false)]
		public bool Survived { get; set; }

		[Name("Sex")]
		[DataMember(Name = "sex", EmitDefaultValue = false)]
		public string Sex { get; set; }

		[Name("Age")] public double Age { get; set; }

		[Name("Siblings/Spouses Aboard")] public int SiblingsOrSpousesAboard { get; set; }

		[Name("Parents/Children Aboard")] public int ParentsOrChildrenAboard { get; set; }

		[Name("Fare")] public double Fare { get; set; }
	}
}