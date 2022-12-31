using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTest.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PatternModel
    {
        public int PatternModelId { get; set; }
        public string? PatternName { get; set; }

        public virtual ICollection<DailyProgramSelection> DailyProgramSelections { get; set; } = new ObservableCollection<DailyProgramSelection>();
    }

    public class DailyProgramSelection
    {
        public int Id { get; set; }
        public int PatternModelId { get; set; }
        public virtual PatternModel PatternModel { get; set; }
        public int DailyProgramId { get; set; }
        public virtual DailyProgram DailyProgram { get; set; }
    }

    public class DailyProgram
    {
        public int DailyProgramId { get; set; }

        public string? Name { get; set; }

        public virtual DailyProgramSelection DailyProgramSelection { get; set; }
    }
}
