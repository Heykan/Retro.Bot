using Retro.Bot.Core;
using Retro.Bot.Protocol.Messages.Game.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Retro.Bot.Game.Entity
{
    public class Characteristic
    {
        private Timer _timerRegeneration;

        public int CurrentExperience { get; set; }
        public int StartExperience { get; set; }
        public int EndExperience { get; set; }
        public int Capital { get; set; }
        public int SpellCapital { get; set; }
        public string Alignement { get; set; }
        public int CurrentLife { get; set; }
        public int MaximumLife { get; set; }
        public int CurrentEnergy { get; set; }
        public int MaximumEnergy { get; set; }
        public int IntervalRegeneration { get; set; }

        public Characteristic(Core.Client client)
        {
            client.Network.RegisterMessage<CharacteristicDataMessage>(OnCharacteristicDataMessage, Core.MessagePriority.High);
            client.Network.RegisterMessage<IntervalRegenrationMessage>(OnIntervalRegenerationMessage, MessagePriority.High);
        }

        private void OnIntervalRegenerationMessage(Client client, IntervalRegenrationMessage message)
        {
            IntervalRegeneration = message.Interval;
            _timerRegeneration = new Timer((double)IntervalRegeneration);
            _timerRegeneration.Elapsed += _timerRegeneration_Elapsed;
            _timerRegeneration.Start();
        }

        private void _timerRegeneration_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrentLife += 1;
            if (LifeUpdated != null)
                LifeUpdated(this, EventArgs.Empty);

            if (CurrentLife >= MaximumLife)
            {
                _timerRegeneration.Stop();
                CurrentLife = MaximumLife;
            }
        }

        private void OnCharacteristicDataMessage(Client client, CharacteristicDataMessage message)
        {
            CurrentExperience = message.CurrentExperience;
            StartExperience = message.StartExperience;
            EndExperience = message.EndExperience;
            Capital = message.Capital;
            SpellCapital = message.SpellCapital;
            Alignement = message.Alignement;
            CurrentLife = message.CurrentLife;
            MaximumLife = message.MaximumLife;
            CurrentEnergy = message.CurrentEnergy;
            MaximumEnergy = message.MaximumEnergy;

            if (Updated != null)
                Updated(this, new CharacteristicsUpdatedEventArgs(message));
            if (LifeUpdated != null)
                LifeUpdated(this, EventArgs.Empty);
        }

        #region Events

        public event EventHandler<CharacteristicsUpdatedEventArgs> Updated;
        public event EventHandler LifeUpdated;

        public class CharacteristicsUpdatedEventArgs : EventArgs
        {
            public CharacteristicDataMessage Characteristic { get; private set; }

            public CharacteristicsUpdatedEventArgs(CharacteristicDataMessage characteristic)
            {
                Characteristic = characteristic;
            }
        }

        #endregion
    }
}
