﻿using System;
using Quartz;
using Quartz.Spi;

namespace QuartzTest
{
    public class JobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public JobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                var job = _serviceProvider.GetService(bundle.JobDetail.JobType) as IJob;
                return job;
            }
            catch (Exception e)
            {
                //NLogHelper.Error(e);
            }
            return null;
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}
