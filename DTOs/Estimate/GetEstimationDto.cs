using System.ComponentModel.DataAnnotations;

namespace hakaton_2022_backend.DTOs.Estimate;

public class GetEstimationDto
{
	[Required]
	public bool UseAi { get; set; }

	[Required]
	public int Lines { get; set; }

	[Required]
	[Range(1,10)]
	public int CodeFamiliarity { get; set; }

	[Required]
	[Range(1,10)]
	public int Experience { get; set; }

	[Required]
	[Range(1,10)]
	public int ProjectScale { get; set; }

	[Required]
	[Range(1,10)]
	public int TaskKnowledge { get; set; }

	[Required]
	[Range(1,10)]
	public int Quality { get; set; }
}