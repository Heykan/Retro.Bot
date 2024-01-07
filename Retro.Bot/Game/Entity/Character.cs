using Retro.Bot.Core;
using Retro.Bot.Game.Inventory;
using Retro.Bot.Game.World;
using Retro.Bot.Network;
using Retro.Bot.Protocol.Messages.Game.Entity;
using Retro.Bot.Protocol.Types.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Retro.Bot.Game.Account;

namespace Retro.Bot.Game.Entity
{
    public class Character : IEntity
    {
        private CharacterState characterState = CharacterState.CONNECTED_IDLE;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public Breed Breed { get; set; }
        public int Gender { get; set; }
        public Map Map { get; set; }
        public Inventory.Inventory Inventory { get; set; }
        public Characteristic Characteristic { get; set; }
        public Cell Cell { get; set; }
        public CharacterState CharacterState
        {
            get { return characterState; }
            set
            {
                if (characterState != value)
                {
                    characterState = value;
                    if (StateChanged != null)
                        StateChanged(this, new CharacterStateChangedEventArgs(characterState));
                }
            }
        }

        public Character(Core.Client client, int id, string name, Cell cell)
        {
            Id = id;
            Name = name;
            Cell = cell;

            Map = new Map(client);
            Inventory = new Inventory.Inventory(client);
            Characteristic = new Characteristic(client);

            CharacterState = CharacterState.CONNECTING;

            client.Network.RegisterMessage<CharacterSelectedMessage>(OnCharacterSelectedMessage, MessagePriority.High);
        }

        public bool IsDisconnected() => CharacterState == CharacterState.DISCONNECTED;
        public bool IsChangingToGame() => CharacterState == CharacterState.CHANGING_TO_GAME;
        public bool IsInDialogue() => CharacterState == CharacterState.STORAGE || CharacterState == CharacterState.DIALOGUE || CharacterState == CharacterState.TRADING || CharacterState == CharacterState.BUYING || CharacterState == CharacterState.SELLING;
        public bool IsFighting() => CharacterState == CharacterState.FIGHTING;
        public bool IsGathering() => CharacterState == CharacterState.GATHERING;
        public bool IsMoving() => CharacterState == CharacterState.MOVING;


        public void OnCharacterSelectedMessage(Core.Client client, CharacterSelectedMessage message)
        {
            Id = message.Character.Id;
            Name = message.Character.Name;
            Level = message.Character.Level;
            Gender = message.Character.Gender;
            Breed = message.Character.Breed;

            client.Logger.Append($"Personnage [bold]{message.Character.Name}[/bold] chargé avec succès.");

            client.Account.Character.CharacterState = CharacterState.CONNECTED_IDLE;


            if (Loaded != null)
                Loaded(this, new CharacterLoadedEventArgs(this));
        }

        #region Event

        public event EventHandler<CharacterLoadedEventArgs> Loaded;
        public event EventHandler<CharacterStateChangedEventArgs> StateChanged;

        public class CharacterStateChangedEventArgs : EventArgs
        {
            public CharacterState State { get; set; }

            public CharacterStateChangedEventArgs(CharacterState state)
            {
                State = state;
            }
        }

        public class CharacterLoadedEventArgs : EventArgs
        {
            public Character Character { get; set; }
            public CharacterLoadedEventArgs(Character character)
            {
                Character = character;
            }
        }

        #endregion
    }
}
