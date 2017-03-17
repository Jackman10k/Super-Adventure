using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class LivingCreature : INotifyPropertyChanged
    {
        private int _currentHitPoints;
        private int _maximumHitPoints;
        private int _currentAbilityPoints;
        private int _maximumAbilityPoints;
        private int _strength;
        private int _defense;
        private int _intelligence;
        private int _magicDefense;

        public int CurrentHitPoints
        {
            get { return _currentHitPoints; }
            set
            {
                _currentHitPoints = value;
                OnPropertyChanged("CurrentHitPoints");
            }
        }

        public int MaximumHitPoints {
            get { return _maximumHitPoints; }
            set
            {
                _maximumHitPoints = value;
                OnPropertyChanged("MaximumHitPoints");
            }
        }

        public int CurrentAbilityPoints
        {
            get { return _currentAbilityPoints; }
            set
            {
                _currentAbilityPoints = value;
                OnPropertyChanged("CurrentAbilityPoints");
            }
        }

        public int MaximumAbilityPoints
        {
            get { return _maximumAbilityPoints; }
            set
            {
                _maximumAbilityPoints = value;
                OnPropertyChanged("MaximumAbilityPoints");
            }
        }

        public int Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
                OnPropertyChanged("Strength");
            }
        }

        public int Defense
        {
            get { return _defense; }
            set
            {
                _defense = value;
                OnPropertyChanged("Defense");
            }
        }

        public int Intelligence
        {
            get { return _intelligence; }
            set
            {
                _intelligence = value;
                OnPropertyChanged("Intelligence");
            }
        }

        public int MagicDefense
        {
            get { return _magicDefense; }
            set
            {
                _magicDefense = value;
                OnPropertyChanged("MagicDefense");
            }
        }
        public List<string> Weaknesses { get; set; }
        public List<string> Resistances { get; set; }
        public BindingList<Ability> AbilityList { get; set; }

        public LivingCreature(int currentHitPoints, int maximumHitPoints, int currentAbilityPoints, int maximumAbilityPoints, int strength, int defense,
            int intelligence, int magicDefense)
        {
            CurrentHitPoints = currentHitPoints;
            MaximumHitPoints = maximumHitPoints;
            CurrentAbilityPoints = currentAbilityPoints;
            MaximumAbilityPoints = maximumAbilityPoints;
            Strength = strength;
            Defense = defense;
            Intelligence = intelligence;
            MagicDefense = magicDefense;
            
            Weaknesses = new List<string>();
            Resistances = new List<string>();
            AbilityList = new BindingList<Ability>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}