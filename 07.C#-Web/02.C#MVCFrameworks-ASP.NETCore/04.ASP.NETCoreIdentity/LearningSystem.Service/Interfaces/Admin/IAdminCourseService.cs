﻿namespace LearningSystem.Service.Interfaces.Admin
{
    using LearningSystem.Service.Models.Course;
    using System;
    using System.Threading.Tasks;

    public interface IAdminCourseService
    {
        Task CreateCourseAsync(string name, string description, DateTime startDate, DateTime endDate, string trainerId);

        
    }
}
