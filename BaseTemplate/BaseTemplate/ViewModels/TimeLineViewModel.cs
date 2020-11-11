using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaseTemplate.Models;
using BaseTemplate.Services;
using Refit;
using TemplateFoundation.ViewModelFoundation;
using Xamarin.Forms;

namespace BaseTemplate.ViewModels
{
    public class TimeLineViewModel : BaseViewModel
    {
        const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoiOGEyMGI3NDMtZDAyYS00OGZlLThkMzktMzhiOGJmZTdjM2I5IiwibmJmIjoxNjA0OTM3NDAzLCJleHAiOjE2MDc1Mjk0MDMsImlhdCI6MTYwNDkzNzQwMywiaXNzIjoiUEhSLlNlcnZpY2UiLCJhdWQiOiJodHRwczovL3Boci5hbmRhbHVzaWFncm91cC5uZXQ6ODAvYXBpLyJ9.MLLBokJoGS8rnuloGIXnTmDhJHitKcqBnQ1khx5IMF8";
        public ObservableCollection<TimelineGroupListUIModel> MedicalHistoryCollection { get; set; } = new ObservableCollection<TimelineGroupListUIModel>();

        public Command LoadDataCommand { get; set; }
        public TimeLineViewModel()
        {
            Title = "Medical History";
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            Task.Run(async () => await FetchData());
        }

        public async Task FetchData()
        {
            IAndalusiaApi AndApi = RestService.For<IAndalusiaApi>("https://phr.andalusiagroup.net");
            List<TimelineGroupListUIModel> result = new List<TimelineGroupListUIModel>();
            try
            {
                var responseData = await AndApi.FetchMedicalHistory(Token, new Models.MedicalHistoryRequest { id = "8a20b743-d02a-48fe-8d39-38b8bfe7c3b9", updatedDate = null });
                var GroupedResponse = responseData.result.Where(x => x.monthInNumbers != 0).Distinct().OrderByDescending(x => x.year)
                   .ThenByDescending(x => x.monthInNumbers).ThenByDescending(x => x.creationDate)
                   .GroupBy(x => x.monthYear);

                foreach (var group in GroupedResponse)
                {
                    var templist = group.ToList();
                    var tempdata = new List<TimeLineByCategoryUIModel>();
                    foreach (var medicalItem in templist)
                    {
                        tempdata.Add(new TimeLineByCategoryUIModel
                        {
                            ID = medicalItem.id,
                            Month = medicalItem.month.ToString(),
                            YEAR = medicalItem.year.ToString(),
                            MonthYear = medicalItem.monthYear,
                            Category = medicalItem.category,
                            CategoryImgSrc = $"{medicalItem.category.ToString().ToLower()}.png",
                            Title = (medicalItem.titleEn.Length > 50) ? medicalItem.titleEn.Substring(0, 47) + "..." : medicalItem.titleEn,
                            HasImageAttachment = medicalItem.hasImageAttachment,
                            HasPDFAttachment = medicalItem.hasImageAttachment,
                            ActiveChronicFlag = medicalItem.chronic ? 1 : medicalItem.active ? 2 : 3,
                            activeChronicText = medicalItem.chronic ? "Chronic" : medicalItem.active ? "Active" : string.Empty
                        });
                    }
                    TimelineGroupListUIModel temp = new TimelineGroupListUIModel(new YearMonth { Month = templist[0].month.ToString(), Year = templist[0].year.ToString() }, tempdata);
                    MedicalHistoryCollection.Add(temp);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
