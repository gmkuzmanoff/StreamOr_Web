using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamOr.Core.Models
{
	public class RadioDeleteViewModel
	{
		private string title;

		public RadioDeleteViewModel() 
		{ 
		}	


		public string Id { get; set; }

		public string Title
		{
			get => title;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					value = $"Unknown title";
				}
				title = value;
			}
		}
	}
}
