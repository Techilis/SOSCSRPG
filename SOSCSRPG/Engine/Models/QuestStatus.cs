using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// To track whether quest is completed or not and is held by player
namespace Engine.Models
{
    public class QuestStatus
    {
        public Quest PlayerQuest { get; set; }
        public bool IsCompleted { get; set; }
        public QuestStatus(Quest quest)
        {
            PlayerQuest = quest;
            IsCompleted = false;
        }
    }
}
