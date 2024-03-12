﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Entities;

public class MyAction
{
    public int Id { get; set; }
    public int ChartPeriodId { get; set; }
    public int PracticeId { get; set; }
    public int OccurenceId { get; set; }
    [StringLength(200)]
    public string Title { get; set; }
    [StringLength(2000)]
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}
