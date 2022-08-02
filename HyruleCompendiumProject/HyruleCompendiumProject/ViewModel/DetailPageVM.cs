using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using HyruleCompendiumProject.Model;

namespace HyruleCompendiumProject.ViewModel
{
    public sealed class DetailPageVM : ViewModelBase
    {
        private DataEntry entry;
        public DataEntry CurrentEntry
        {
            get { return entry; }
            set { entry = value; SetDetailPageValues(); }
        }

        private string leftType;
        public string LeftType
        {
            get { return leftType; }
            set { leftType = value; }
        }

        private List<string> leftTypeValue;
        public List<string> LeftTypeValue
        {
            get { return leftTypeValue; }
            set { leftTypeValue = value; }
        }

        private string rightType;
        public string RightType
        {
            get { return rightType; }
            set { rightType = value; }
        }

        private List<string> rightTypeValue;
        public List<string> RightTypeValue
        {
            get { return rightTypeValue; }
            set { rightTypeValue = value; }
        }

        void SetDetailPageValues()
        {
            switch (entry.Category)
            {
                case "creatures":
                    if (CurrentEntry is CreatureFoodEntry foodCreature)
                    {
                        LeftType = "Hearts recovered";
                        LeftTypeValue = new List<string> { foodCreature.HeartsRecovered };
                        RightType = "Cooking Effects";
                        RightTypeValue = new List<string> { foodCreature.CookingEffects };
                    }
                    else if (CurrentEntry is CreatureNonFoodEntry nonfoodCreature)
                    {
                        LeftType = "Recoverable Materials";
                        LeftTypeValue = (nonfoodCreature.Drops == null || nonfoodCreature.Drops.Count() == 0) ? new List<string> { "unknown" } : nonfoodCreature.Drops;
                        RightType = "";
                        RightTypeValue = new List<string>();
                    }
                    break;
                case "monsters":
                    LeftType = "Recoverable Materials";
                    LeftTypeValue = (CurrentEntry as MonsterEntry).Drops;
                    RightType = "";
                    RightTypeValue = new List<string>();
                    break;
                case "materials":
                    LeftType = "Hearts recovered";
                    LeftTypeValue = new List<string> { (CurrentEntry as MaterialEntry).HeartsRecovered };
                    RightType = "Cooking Effects";
                    RightTypeValue = new List<string> { (CurrentEntry as MaterialEntry).CookingEffects };
                    break;
                case "equipment":
                    LeftType = "";
                    LeftTypeValue = new List<string>();
                    RightType = "Properties";
                    RightTypeValue = new List<string> { $"attack = {(CurrentEntry as EquipmentEntry).Attack}", $"defense = {(CurrentEntry as EquipmentEntry).Defense}" };
                    break;
                case "treasure":
                    LeftType = "Recoverable Materials";
                    LeftTypeValue = (CurrentEntry as TreasureEntry).Drops;
                    RightType = "";
                    RightTypeValue = new List<string>();
                    break;
            }
            RaisePropertyChanged("CurrentEntry");
            RaisePropertyChanged("LeftType");
            RaisePropertyChanged("LeftTypeValue");
            RaisePropertyChanged("RightType");
            RaisePropertyChanged("RightTypeValue");
        }
    }
}
