using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BaseTemplate.Models
{
	public class TimelineGroupListUIModel :List<TimeLineByCategoryUIModel>
	{
		public YearMonth YearMonth { get; set; }
		public List<TimeLineByCategoryUIModel> Groups { get;set; }
		public TimelineGroupListUIModel(YearMonth yearMonth, List<TimeLineByCategoryUIModel> items) : base(items)
		{
			YearMonth = yearMonth;
		}
	}
	public class TimeLineByCategoryUIModel : BaseModel
	{
		public long TableID { get; set; }
		public string Title { get; set; }
		public string Month { get; set; }
		public string MonthYear { get; set; }
		public int MonthInNumbers { get; set; }
		public string YEAR { get; set; }
		public bool Active { get; set; }
		public bool Chronic { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string Category { get; set; }
		public ImageSource CategoryImgSrc { get; set; }
		public Thickness activeChronicMargin { get; set; }
		public bool activeChronicHasShadow { get; set; }
		public string activeChronicText { get; set; }
		public Color activeChronicTextColor { get; set; }
		public Color activeChronicBackgroundColor { get; set; }
		public bool HasImageAttachment { get; set; }
		public bool HasPDFAttachment { get; set; }
		public string CategoryColor { get; set; }
		public int ActiveChronicFlag { get; set; }
	}

	public class YearMonth
	{
		public string Year { get; set; }
		public string Month { get; set; }
	}
}
