﻿using Refit;
using RemoteData.HTTPModel.ActivityList;
using RemoteData.Interface.AcitvityList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.EndPoint.AvitvityList
{
    public class AddActivityListEndPoint
    {
        public ActivityRequestModel AddActivityRequestModel { get; set; }
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await 
                RestService.For<IAddActivityListApi>("https://fakerestapi.azurewebsites.net/api/v1/").AddActivity(AddActivityRequestModel);
        }
    }
}
