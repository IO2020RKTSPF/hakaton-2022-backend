using System.ComponentModel.DataAnnotations;

namespace hakaton_2022_backend.Application.DTOs.Estimate;

public class GetEstimationDto
{
	public string? Name { get; set; }
	
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