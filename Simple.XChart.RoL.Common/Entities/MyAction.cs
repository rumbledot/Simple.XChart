using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Entities;

public class MyAction
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Occurence { get; set; }
    public int PracticeId { get; set; }
    public int TaskId { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}
