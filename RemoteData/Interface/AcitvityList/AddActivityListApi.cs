﻿using Refit;
using RemoteData.HTTPModel.ActivityList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteData.Interface.AcitvityList
{
    public interface IAddActivityListApi
    {
        [Post("/Activities")]
        Task<HttpResponseMessage> AddActivity([Body] ActivityRequestModel model);

    }
}
