namespace AppData.DataModels
{
    public class PowerPlantDto
        {
            public string Name { get; set; }
        
            public PPType Type { get; set; }

            public decimal Efficiency { get; set; }

            public decimal PMin { get; set; }
        
            public decimal PMax { get; set; }
           
        
        }
    }
